using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

/// <summary>
/// ���а����
/// </summary>
public class RankPanel : BasePanel<RankPanel>
{
    public Transform UICloseBtn;
    public Transform UIScrollView;
    //�������а��б�
    private List<RankItem> listRankItems = new List<RankItem>();


    public override void Init()
    {
        UICloseBtn.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {
            HideMe();
        }));
        
        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        List<RankItemData> rankItemDatas = GameDataMgr.Instance.rankData.listItemData;
        //��������
        //List<RankItemData> rankItemDatas = new List<RankItemData>() { new RankItemData() {name="hyq",score=99,time=99 },
                                                                     // new RankItemData() {name="hyq2",score=97,time=99 } };

        //Debug.Log("���а����ݣ�" + rankItemDatas.Count);
        //Debug.Log("���а񵥸���" + listRankItems.Count);
        for (int i = 0; i < rankItemDatas.Count; i++)
        {
            //������ʱ ֱ�Ӵ���
            if(listRankItems.Count>i)
            {
                listRankItems[i].InitInfo(i, rankItemDatas[i].name, rankItemDatas[i].score, rankItemDatas[i].time);
            }
            else
            {
                //ʵ����
                GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/UI/RankItem"));
                //����λ��
                Transform scrollViewContent = UIScrollView.GetComponent<ScrollRect>().content;
                obj.transform.SetParent(scrollViewContent, false);
                RankItem item = obj.GetComponent<RankItem>();
                //���а���Ϣ
                item.InitInfo(i, rankItemDatas[i].name, rankItemDatas[i].score, rankItemDatas[i].time);
                listRankItems.Add(item);
            }
        }

    }

}
