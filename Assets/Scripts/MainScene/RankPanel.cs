using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

/// <summary>
/// 排行榜面板
/// </summary>
public class RankPanel : BasePanel<RankPanel>
{
    public Transform UICloseBtn;
    public Transform UIScrollView;
    //单个排行榜列表
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
        //测试数据
        //List<RankItemData> rankItemDatas = new List<RankItemData>() { new RankItemData() {name="hyq",score=99,time=99 },
                                                                     // new RankItemData() {name="hyq2",score=97,time=99 } };

        //Debug.Log("排行榜数据：" + rankItemDatas.Count);
        //Debug.Log("排行榜单个：" + listRankItems.Count);
        for (int i = 0; i < rankItemDatas.Count; i++)
        {
            //有数据时 直接创建
            if(listRankItems.Count>i)
            {
                listRankItems[i].InitInfo(i, rankItemDatas[i].name, rankItemDatas[i].score, rankItemDatas[i].time);
            }
            else
            {
                //实例化
                GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/UI/RankItem"));
                //设置位置
                Transform scrollViewContent = UIScrollView.GetComponent<ScrollRect>().content;
                obj.transform.SetParent(scrollViewContent, false);
                RankItem item = obj.GetComponent<RankItem>();
                //排行榜信息
                item.InitInfo(i, rankItemDatas[i].name, rankItemDatas[i].score, rankItemDatas[i].time);
                listRankItems.Add(item);
            }
        }

    }

}
