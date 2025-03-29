using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel<GamePanel>
{
    public Transform UIOptionBtn;
    public Transform UIBackBtn;
    public Transform UITime;
    public Transform UIScore;
    public List<Transform> UIHp;
    public float nowTime = 0f;
    public float lastTime = 0f;
    public float tickTime = 0f;

    public override void Init()
    {
        UIOptionBtn.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            //print("UIOptionBtn On Click");
            PlayerControl.Instance.GamePause();
            OptionPanel.Instance.ShowMe();
        }));

        UIBackBtn.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            //print("UIBackBtn On Click");
            PlayerControl.Instance.GamePause();
            SureBackPanel.Instance.ShowMe();
        }));

        UITime.GetComponent<Text>();
    }

    private void Update()
    {
        tickTime += Time.deltaTime;

        if (PlayerControl.Instance.gameContinue&&tickTime>=3f)
        {
            nowTime += Time.deltaTime;
            string str = "";
            //小时h
            if ((int)nowTime / 3600 > 0)
                str += ((int)nowTime / 3600).ToString() + "h";
            //分钟m
            if ((int)nowTime % 3600 / 60 > 0)
            {
                str += ((int)nowTime % 3600 / 60).ToString() + "m";
            }
            //秒s
            str += ((int)nowTime % 60).ToString() + "s";
            UITime.GetComponent<Text>().text = str;

            //改变玩家的移动速度 每5s加一次
            if (nowTime - lastTime >= 5f)
            {
                if (PlayerControl.Instance.moveSpeed <= 15)
                    PlayerControl.Instance.moveSpeed++;
                if (PlayerControl.Instance.hSpeed <= 15)
                    PlayerControl.Instance.hSpeed++;
                lastTime = nowTime;
                //Debug.Log("玩家移动速度:" + PlayerControl.Instance.moveSpeed);
            }
        }



    }

    //public void TimeUpdate(int time)
    //{
    //    string str = "";
    //    //小时h
    //    if (time / 3600 > 0)
    //        str += (time / 3600).ToString() + "h";
    //    //分钟m
    //    if (time % 3600 / 60 > 0)
    //        str += (time % 3600 / 60).ToString() + "m";
    //    //秒s
    //    str += (time % 60).ToString() + "s";
    //    UITime.GetComponent<Text>().text = str;
    //}

}
