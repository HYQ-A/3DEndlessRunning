using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SureBackPanel : BasePanel<SureBackPanel>
{
    public Transform UIYesBtn;
    public Transform UINoBtn;

    public override void Init()
    {
        UIYesBtn.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            SceneManager.LoadScene("MainScene");
        }));

        UINoBtn.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            HideMe();
            PlayerControl.Instance.GameRecover();
        }));

        HideMe();
    }

}
