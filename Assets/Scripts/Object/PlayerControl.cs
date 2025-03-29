using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    private static PlayerControl instance;
    public static PlayerControl Instance => instance;

    public float moveSpeed;
    public float hSpeed;//左右移动速度
    private float hValue;
    public float jumpHeight;
    public float jumpDuration;
    private bool isJumping = false;
    public Animator ani;
    private Vector3 startPosition;
    public GameObject roadObj;//关联初始的路段
    private int hp = 3;
    private float frontMoveSpeed;//用于存储之前的奔跑速度
    private float fronthSpeed;//用于存储之前的横向移动速度
    public bool gameContinue = true;
    private float tickTime = 0f;//用于一开始倒计时
    public int score = 0;

    private void Awake()
    {
        instance = this;
        ani = this.gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        fronthSpeed = hSpeed;
        frontMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        tickTime += Time.deltaTime;
        if(tickTime>=3f)
        {
            ani.SetBool("Start", true);
            //不断往前跑
            if (gameContinue)
                this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            //左右移动
            if (gameContinue)
                hValue = Input.GetAxisRaw("Horizontal");
            if (hValue == 0)
                this.gameObject.transform.rotation = Quaternion.identity;
            else
            {
                this.gameObject.transform.Translate(Vector3.right * hValue * Time.deltaTime * hSpeed);
            }

            //跳跃
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                //Debug.Log("跳跃");
                StartCoroutine(JumpRoutine());
            }
        }

    }

    /// <summary>
    /// 碰撞检测
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        //摧毁障碍
        if (other.gameObject.CompareTag("Obstacle"))
        {
            //撞到障碍减速
            moveSpeed = moveSpeed > 0 ? moveSpeed-- : 1;
            fronthSpeed = moveSpeed;

            //Debug.Log("进入碰撞检测");
            Destroy(other.gameObject);
            List<Transform> listHp = GamePanel.Instance.UIHp;
            if(--hp>=0)
            {
                listHp[hp].GetComponent<UnityEngine.UI.Image>().fillAmount = 0;
                listHp[hp].GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                Death();
            }
        }

        //生成路段,障碍物生成
        if(other.CompareTag("Road"))
        {
            int a = Random.Range(1, 4);
            string path = $"prefabs/Environment/Road/Road{a}";//路段生成路径
            string pathBa = $"prefabs/Environment/Obstacle/";//障碍物生成路径
            GameObject obj;
            //路段生成
            obj = Instantiate(Resources.Load<GameObject>(path));
            obj.transform.position = other.gameObject.transform.position + Vector3.forward * 82;
            //Debug.Log("碰撞器名字：" + other.gameObject.name + "碰撞器位置：" + other.gameObject.transform.position + "生成的路段名字：" + obj.name);
            //障碍物生成
            obj.GetComponent<RoadObj>().CreatRoad(pathBa);

            //生成金币
            obj.GetComponent<RoadObj>().CreateCoin();

            //房屋生成
            //Debug.Log("调用房屋生成");
            float p = HouseObj.Instance.CreateHouse();
            HouseObj.Instance.p1 = p;
            HouseObj.Instance.p2 = p;

            Destroy(other.gameObject, 3f);
            
        }

        //金币
        if(other.gameObject.CompareTag("Coin"))
        {
            //Debug.Log("与金币碰撞");
            Destroy(other.gameObject);
            GamePanel.Instance.UIScore.GetComponent<Text>().text = (++score).ToString();
        }
    }

    //TODO:协程跳跃与左右移动回顾
    IEnumerator JumpRoutine()
    {
        Rigidbody rig = this.gameObject.GetComponent<Rigidbody>();
        isJumping = true;
        ani.SetBool("Jump", true);
        startPosition = this.gameObject.transform.position;
        float elapsedTime = 0f;
        Vector3 totalHMove = Vector3.zero;

        // 跳跃期间持续应用前进和横向移动
        while (elapsedTime < jumpDuration)
        {
            // 计算垂直位移（抛物线）
            float progress = elapsedTime / jumpDuration;
            float yOffset = Mathf.Sin(progress * Mathf.PI) * jumpHeight;

            // 计算水平位移：前进 + 横向输入
            //Vector3 hMove = Vector3.right * Input.GetAxisRaw("Horizontal") * hSpeed * Time.deltaTime;
            //totalHMove += hMove;

            // 更新位置：水平移动 + 垂直偏移
            transform.position = startPosition +
                                 Vector3.forward * moveSpeed * Time.deltaTime * (elapsedTime / Time.deltaTime) +
                                 Vector3.up * yOffset;
                                 //totalHMove;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 确保最终位置包含所有水平移动
        transform.position = startPosition + Vector3.forward * moveSpeed * jumpDuration;//+ totalHMove;
        ani.SetBool("Jump", false);
        isJumping = false;

    }

    /// <summary>
    /// 游戏暂停方法
    /// </summary>
    public void GamePause()
    {
        StopCoroutine(JumpRoutine());
        gameContinue = false;
        isJumping = true;
        moveSpeed = 0f;
        hSpeed = 0f;
        ani.SetBool("Death", true);
    }

    /// <summary>
    /// 取消暂停恢复游戏方法
    /// </summary>
    public void GameRecover()
    {
        isJumping = false;
        moveSpeed = frontMoveSpeed;
        gameContinue = true;
        hSpeed = fronthSpeed;
        ani.SetBool("Death", false);
    }

    /// <summary>
    /// 角色死亡方法
    /// </summary>
    public void Death()
    {
        //Debug.Log("Player Death");
        GamePause();
        GameOverPanel.Instance.ShowMe();
    }
}
