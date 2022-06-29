using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.gameObject.tag = "Collected";
            PlayerManager.instance.StackMoney(other.gameObject,PlayerManager.instance.moneys.Count-1);
        }else if (other.CompareTag("ElmasKapi"))
        {
            ElmasaDonustur(other.GetComponent<KapiManager>().ElmasMat);
        }
    }
    void ElmasaDonustur(Material ElmasMat)
    {
        GetComponent<MeshRenderer>().material = ElmasMat;
    }
}
