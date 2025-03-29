using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankItem : MonoBehaviour
{
    public Transform UIRank;
    public Transform UIName;
    public Transform UIScore;
    public Transform UITime;

    /// <summary>
    /// �ṩ���ⲿ��ʼ������
    /// </summary>
    /// <param name="rank"></param>
    /// <param name="name"></param>
    /// <param name="score"></param>
    /// <param name="time"></param>
    public void InitInfo(int rank,string name,int score,int time)
    {
        UIRank.GetComponent<Text>().text = rank.ToString();
        UIName.GetComponent<Text>().text = name;
        UIScore.GetComponent<Text>().text = score.ToString();

        string str = "";
        //Сʱh
        if (time / 3600 > 0)
            str = (time / 3600).ToString() + "h";
        //����m
        if (time % 3600 / 60 > 0)
            str += (time / 3600 / 60).ToString() + "m";
        //��s
        str += (time % 60).ToString() + "s";
        UITime.GetComponent<Text>().text = str;
    }
}
