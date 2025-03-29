using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseObj : MonoBehaviour
{
    private static HouseObj instance;
    public static HouseObj Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    private GameObject houseObj1;
    //private GameObject houseObj2;
    public float p1 = 62.49f;
    public float p2 = 62.43f;

    public float CreateHouse()
    {
        for(int i=1;i<=6;i++)
        {
            houseObj1 = Instantiate(Resources.Load<GameObject>("Prefabs/Environment/House/house"));
            houseObj1.transform.position = new Vector3(-6.43f, 1.30326f, p1 + 5);
            p1 += 5;
            //HouseDes();
            Destroy(houseObj1, 20f);
        }
        //Debug.Log("生成一次房屋");
        for (int i = 1; i <= 6; i++)
        {
            houseObj1 = Instantiate(Resources.Load<GameObject>("Prefabs/Environment/House/house"));
            houseObj1.transform.position = new Vector3(4.33f, 1.30326f, p2 + 5);
            p2 += 5;
            Destroy(houseObj1, 20f);
            //HouseDes();
        }
        //Debug.Log("最后一次创建房屋返回位置：" + p2);
        return p2;

    }

    //IEnumerator HouseDes()
    //{

    //}
    
}
