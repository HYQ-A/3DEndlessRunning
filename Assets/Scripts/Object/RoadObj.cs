using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class RoadObj : MonoBehaviour
{
    public List<GameObject> fatherBa;//·�����ϵ������ϰ��������
    public List<GameObject> coins;

    /// <summary>
    /// ��������ϰ��﷽��
    /// </summary>
    /// <param name="road"></param>
    public void CreatRoad(string path)
    {
        int a = Random.Range(3, fatherBa.Count + 1);//�ϰ�������常����
        int b;//�ϰ���
        for (int i = 0; i < a; i++)
        {
            b = Random.Range(1, 4);//�ϰ���
            GameObject baObj = Instantiate(Resources.Load<GameObject>(path+$"Ba{b}"));//�ϰ���
            baObj.transform.SetParent(fatherBa[i].transform, false);
            baObj.transform.localPosition = Vector3.zero;
            if(b==3)
            {
                baObj.transform.localScale = new Vector3(0.0772057f, 0.03501412f, 0.3913782f);
                baObj.transform.localPosition += new Vector3(0, 0, 0.0076258f);
            }
        }
    }

    public void CreateCoin()
    {
        int a = Random.Range(10, coins.Count);
        for (int i = 1; i <= a; i++)
        {
            GameObject coinObj = Instantiate(Resources.Load<GameObject>("Prefabs/Environment/Coins/Coin"));
            coinObj.transform.SetParent(coins[i].transform, false);
            coinObj.transform.localPosition = Vector3.zero;
            //Debug.Log("���ɽ�ң�" + coinObj.transform.position);
        }
    }
}
