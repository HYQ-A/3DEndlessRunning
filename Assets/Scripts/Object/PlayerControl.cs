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
    public float hSpeed;//�����ƶ��ٶ�
    private float hValue;
    public float jumpHeight;
    public float jumpDuration;
    private bool isJumping = false;
    public Animator ani;
    private Vector3 startPosition;
    public GameObject roadObj;//������ʼ��·��
    private int hp = 3;
    private float frontMoveSpeed;//���ڴ洢֮ǰ�ı����ٶ�
    private float fronthSpeed;//���ڴ洢֮ǰ�ĺ����ƶ��ٶ�
    public bool gameContinue = true;
    private float tickTime = 0f;//����һ��ʼ����ʱ
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
            //������ǰ��
            if (gameContinue)
                this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            //�����ƶ�
            if (gameContinue)
                hValue = Input.GetAxisRaw("Horizontal");
            if (hValue == 0)
                this.gameObject.transform.rotation = Quaternion.identity;
            else
            {
                this.gameObject.transform.Translate(Vector3.right * hValue * Time.deltaTime * hSpeed);
            }

            //��Ծ
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                //Debug.Log("��Ծ");
                StartCoroutine(JumpRoutine());
            }
        }

    }

    /// <summary>
    /// ��ײ���
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        //�ݻ��ϰ�
        if (other.gameObject.CompareTag("Obstacle"))
        {
            //ײ���ϰ�����
            moveSpeed = moveSpeed > 0 ? moveSpeed-- : 1;
            fronthSpeed = moveSpeed;

            //Debug.Log("������ײ���");
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

        //����·��,�ϰ�������
        if(other.CompareTag("Road"))
        {
            int a = Random.Range(1, 4);
            string path = $"prefabs/Environment/Road/Road{a}";//·������·��
            string pathBa = $"prefabs/Environment/Obstacle/";//�ϰ�������·��
            GameObject obj;
            //·������
            obj = Instantiate(Resources.Load<GameObject>(path));
            obj.transform.position = other.gameObject.transform.position + Vector3.forward * 82;
            //Debug.Log("��ײ�����֣�" + other.gameObject.name + "��ײ��λ�ã�" + other.gameObject.transform.position + "���ɵ�·�����֣�" + obj.name);
            //�ϰ�������
            obj.GetComponent<RoadObj>().CreatRoad(pathBa);

            //���ɽ��
            obj.GetComponent<RoadObj>().CreateCoin();

            //��������
            //Debug.Log("���÷�������");
            float p = HouseObj.Instance.CreateHouse();
            HouseObj.Instance.p1 = p;
            HouseObj.Instance.p2 = p;

            Destroy(other.gameObject, 3f);
            
        }

        //���
        if(other.gameObject.CompareTag("Coin"))
        {
            //Debug.Log("������ײ");
            Destroy(other.gameObject);
            GamePanel.Instance.UIScore.GetComponent<Text>().text = (++score).ToString();
        }
    }

    //TODO:Э����Ծ�������ƶ��ع�
    IEnumerator JumpRoutine()
    {
        Rigidbody rig = this.gameObject.GetComponent<Rigidbody>();
        isJumping = true;
        ani.SetBool("Jump", true);
        startPosition = this.gameObject.transform.position;
        float elapsedTime = 0f;
        Vector3 totalHMove = Vector3.zero;

        // ��Ծ�ڼ����Ӧ��ǰ���ͺ����ƶ�
        while (elapsedTime < jumpDuration)
        {
            // ���㴹ֱλ�ƣ������ߣ�
            float progress = elapsedTime / jumpDuration;
            float yOffset = Mathf.Sin(progress * Mathf.PI) * jumpHeight;

            // ����ˮƽλ�ƣ�ǰ�� + ��������
            //Vector3 hMove = Vector3.right * Input.GetAxisRaw("Horizontal") * hSpeed * Time.deltaTime;
            //totalHMove += hMove;

            // ����λ�ã�ˮƽ�ƶ� + ��ֱƫ��
            transform.position = startPosition +
                                 Vector3.forward * moveSpeed * Time.deltaTime * (elapsedTime / Time.deltaTime) +
                                 Vector3.up * yOffset;
                                 //totalHMove;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ȷ������λ�ð�������ˮƽ�ƶ�
        transform.position = startPosition + Vector3.forward * moveSpeed * jumpDuration;//+ totalHMove;
        ani.SetBool("Jump", false);
        isJumping = false;

    }

    /// <summary>
    /// ��Ϸ��ͣ����
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
    /// ȡ����ͣ�ָ���Ϸ����
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
    /// ��ɫ��������
    /// </summary>
    public void Death()
    {
        //Debug.Log("Player Death");
        GamePause();
        GameOverPanel.Instance.ShowMe();
    }
}
