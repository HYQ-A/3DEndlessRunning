using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanel : BasePanel<OptionPanel>
{
    public Transform UICloseBtn;
    public Transform UIMusicSlider;
    public Transform UISoundSlider;
    public Transform UIMusicTog;
    public Transform UISoundTog;
    private bool MusicTog = false;
    private bool SoundTog;

    public override void Init()
    {
        UICloseBtn.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            HideMe();
            if(MainPanel.Instance.sceneChange)
            {
                PlayerControl.Instance.GameRecover();
            }

        }));

        UIMusicSlider.GetComponent<Slider>().onValueChanged.AddListener(new UnityEngine.Events.UnityAction<float>((a) =>
        {
            //print("UIMusicSlider a:" + a.ToString());
        }));

        UISoundSlider.GetComponent<Slider>().onValueChanged.AddListener(new UnityEngine.Events.UnityAction<float>((a) =>
        {
            //print("UISoundSlider a:" + a.ToString());
        }));

        UIMusicTog.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            UIMusicTog.GetChild(0).gameObject.SetActive(!MusicTog);
            MusicTog = !MusicTog;
        }));

        UISoundTog.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            UISoundTog.GetChild(0).gameObject.SetActive(!SoundTog);
            SoundTog = !SoundTog;
        }));

        HideMe();
        //TODO:一开始就设置音乐音效打开 后续需要调整
        UIMusicTog.GetChild(0).gameObject.SetActive(false);
        UISoundTog.GetChild(0).gameObject.SetActive(false);
    }

}
