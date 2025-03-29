using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinObj : MonoBehaviour
{
    public GameObject coinObj;
    public float rotateSpeed;
    //public static int score = 0;

    // Update is called once per frame
    void Update()
    {
        coinObj.gameObject.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime*10);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(coinObj);
    //        GamePanel.Instance.UIScore.GetComponent<Text>().text = (++score).ToString();
    //    }
    //}
}
