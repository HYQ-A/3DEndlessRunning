using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPanel : BasePanel<MainPanel>
{
    public Transform UIStartBtn;
    public Transform UIRankBtn;
    public Transform UIOptionBtn;
    public Transform UIQuitBtn;
    public bool sceneChange = false;


    public override void Init()
    {
        //��ʼ��ť����
        UIStartBtn.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            //print("UIStartBtn On Click");
            sceneChange = true;
            //Debug.Log(Application.persistentDataPath);
            //�������
            SceneManager.LoadScene("GameScene");
        }));

        //���а�ť����
        UIRankBtn.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            //print("UIRankBtn On Click");
            RankPanel.Instance.ShowMe();
            
        }));

        //���ð�ť����
        UIOptionBtn.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            //print("UIOptionBtn On Click");
            OptionPanel.Instance.ShowMe();
        }));

        //�˳���ť����
        UIQuitBtn.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            //print("UIStartBtn On Click");
            Application.Quit();
        }));
    }

}
