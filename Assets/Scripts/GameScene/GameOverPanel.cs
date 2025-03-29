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

        //ʵʱ��������仯
        UIInput.GetComponent<TMP_InputField>().onValueChanged.AddListener(new UnityEngine.Events.UnityAction<string>((a) =>
        {
            //Debug.Log("UIInput ��������" + a);

        }));

        //����������� enter������
        UIInput.GetComponent<TMP_InputField>().onEndEdit.AddListener(new UnityEngine.Events.UnityAction<string>((a) =>
        {
            //Debug.Log("UIInput �������" + a);
            //TODO:���ݴ洢�����а�
            GameDataMgr.Instance.AddRankData(a, (int)GamePanel.Instance.nowTime, PlayerControl.Instance.score);
            //Debug.Log("������" + PlayerControl.Instance.score);
            SceneManager.LoadScene("MainScene");

        }));

        HideMe();

    }

}
