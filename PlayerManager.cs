using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   public  List<GameObject> moneys = new List<GameObject>();
   public float smooth = 0.25f;
   public static PlayerManager instance;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
   }


   public void StackMoney(GameObject other,int index)
   {
      other.transform.parent = transform;
      Vector3 newPos = moneys[index].transform.localPosition;
      newPos.x += 1;
      other.transform.localPosition = newPos;
      moneys.Add(other);
      StartCoroutine(MakeObjectBigger());
   }
   private void Update()
   {
      MoveListObjects();
      this.transform.Translate(5*Time.deltaTime,0,0);
      if (Input.GetKey(KeyCode.A))
      {
         moneys[0].transform.Translate(0,0,5*Time.deltaTime);
      }
      if (Input.GetKey(KeyCode.D))
      {
         moneys[0].transform.Translate(0,0,-5*Time.deltaTime);
      }
   }

   public IEnumerator MakeObjectBigger()
   {
      Vector3 scale = Vector3.one;
      scale *= 1.5f;
      moneys[moneys.Count - 1].transform.DOScale(scale, 0.1f).OnComplete(()=>
      {
         moneys[moneys.Count-1].transform.DOScale(Vector3.one,0.1f);
      });
      yield return new WaitForSeconds(0.05f);
   }

   public void MoveListObjects()
   {
      for (int i = 1; i < moneys.Count; i++)
      {
         Vector3 pos = moneys[i].transform.localPosition;
         pos.z = moneys[i - 1].transform.localPosition.z;
         moneys[i].transform.DOLocalMove(pos, smooth);
      }
   }
}
