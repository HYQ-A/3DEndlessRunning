using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 数据管理类
/// </summary>
public class GameDataMgr 
{
    private static GameDataMgr instance = new GameDataMgr();

    public static GameDataMgr Instance => instance;

    public MusicData musicData;
    public RankData rankData;

    /// <summary>
    /// 初始化游戏所有一开始的数据
    /// </summary>
    private GameDataMgr() 
    {
        musicData = XmlDataMgr.Instance.LoadData(typeof(MusicData), "MusicData") as MusicData;
        rankData = XmlDataMgr.Instance.LoadData(typeof(RankData), "RankData") as RankData;
        //Debug.Log("GameDateMgr执行");
    }

    #region 音乐音效数据管理
    /// <summary>
    /// 提供给外部改变音量大小方法
    /// </summary>
    /// <param name="value"></param>
    public void ChangeMusicValue(float value)
    {
        musicData.musicValue = value;
        //保存音乐数据
        XmlDataMgr.Instance.SaveData(musicData, "MusicData");
    }

    /// <summary>
    /// 提供给外部改变音效大小的方法
    /// </summary>
    /// <param name="value"></param>
    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
        //保存音效数据
        XmlDataMgr.Instance.SaveData(musicData, "MusicData");
    }
    #endregion

    #region 排行榜数据管理

    /// <summary>
    /// 提供给外部添加排行榜数据方法
    /// </summary>
    public void AddRankData(string name, int time,int score)
    {
        RankItemData rankItemData = new RankItemData();
        rankItemData.name = name;
        rankItemData.time = time;
        rankItemData.score = score;
        rankData.listItemData.Add(rankItemData);

        //排序
        rankData.listItemData.Sort((a, b) =>
        {
            if (a.score > b.score) return -1;
            return 1;
        });

        //保存新添加的排行榜数据
        XmlDataMgr.Instance.SaveData(rankData, "RankData");
    }

    #endregion


}
