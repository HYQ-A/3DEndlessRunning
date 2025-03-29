using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : BasePanel<GameOverPanel>
{
    public Transform UIInput;
    public Transform UISureBtn;
    public RankItemData rankItemData = new RankItemData();

    public override void Init()
    {
        UISureBtn.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            //Debug.Log("UISureBtn On Click");

        }));

        //实时监听输入变化
        UIInput.GetComponent<TMP_InputField>().onValueChanged.AddListener(new UnityEngine.Events.UnityAction<string>((a) =>
        {
            //Debug.Log("UIInput 正在输入" + a);

        }));

        //监听输入完成 enter键结束
        UIInput.GetComponent<TMP_InputField>().onEndEdit.AddListener(new UnityEngine.Events.UnityAction<string>((a) =>
        {
            //Debug.Log("UIInput 输入完成" + a);
            //TODO:数据存储到排行榜
            GameDataMgr.Instance.AddRankData(a, (int)GamePanel.Instance.nowTime, PlayerControl.Instance.score);
            //Debug.Log("分数：" + PlayerControl.Instance.score);
            SceneManager.LoadScene("MainScene");

        }));

        HideMe();

    }

}
