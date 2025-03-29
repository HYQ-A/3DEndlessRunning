using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ݹ�����
/// </summary>
public class GameDataMgr 
{
    private static GameDataMgr instance = new GameDataMgr();

    public static GameDataMgr Instance => instance;

    public MusicData musicData;
    public RankData rankData;

    /// <summary>
    /// ��ʼ����Ϸ����һ��ʼ������
    /// </summary>
    private GameDataMgr() 
    {
        musicData = XmlDataMgr.Instance.LoadData(typeof(MusicData), "MusicData") as MusicData;
        rankData = XmlDataMgr.Instance.LoadData(typeof(RankData), "RankData") as RankData;
        //Debug.Log("GameDateMgrִ��");
    }

    #region ������Ч���ݹ���
    /// <summary>
    /// �ṩ���ⲿ�ı�������С����
    /// </summary>
    /// <param name="value"></param>
    public void ChangeMusicValue(float value)
    {
        musicData.musicValue = value;
        //������������
        XmlDataMgr.Instance.SaveData(musicData, "MusicData");
    }

    /// <summary>
    /// �ṩ���ⲿ�ı���Ч��С�ķ���
    /// </summary>
    /// <param name="value"></param>
    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
        //������Ч����
        XmlDataMgr.Instance.SaveData(musicData, "MusicData");
    }
    #endregion

    #region ���а����ݹ���

    /// <summary>
    /// �ṩ���ⲿ������а����ݷ���
    /// </summary>
    public void AddRankData(string name, int time,int score)
    {
        RankItemData rankItemData = new RankItemData();
        rankItemData.name = name;
        rankItemData.time = time;
        rankItemData.score = score;
        rankData.listItemData.Add(rankItemData);

        //����
        rankData.listItemData.Sort((a, b) =>
        {
            if (a.score > b.score) return -1;
            return 1;
        });

        //��������ӵ����а�����
        XmlDataMgr.Instance.SaveData(rankData, "RankData");
    }

    #endregion


}
