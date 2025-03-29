using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReTimePanel : BasePanel<ReTimePanel>
{
    public Transform time;

    public override void Init()
    {

    }

    private void Update()
    {
        if(GamePanel.Instance.tickTime>=3f)
        {
            HideMe();
        }
        else
        {
            if(GamePanel.Instance.tickTime>=1f)
            {
                if (GamePanel.Instance.tickTime >= 2f)
                    time.GetComponent<Text>().text = 1.ToString();
                else
                    time.GetComponent<Text>().text = 2.ToString();
            }
        }
    }

}
