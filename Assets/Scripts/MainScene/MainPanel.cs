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
        //开始按钮监听
        UIStartBtn.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            //print("UIStartBtn On Click");
            sceneChange = true;
            //Debug.Log(Application.persistentDataPath);
            //变更场景
            SceneManager.LoadScene("GameScene");
        }));

        //排行榜按钮监听
        UIRankBtn.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            //print("UIRankBtn On Click");
            RankPanel.Instance.ShowMe();
            
        }));

        //设置按钮监听
        UIOptionBtn.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            //print("UIOptionBtn On Click");
            OptionPanel.Instance.ShowMe();
        }));

        //退出按钮监听
        UIQuitBtn.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            //print("UIStartBtn On Click");
            Application.Quit();
        }));
    }

}
