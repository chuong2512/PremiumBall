using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasingManager : MonoBehaviour
{
   public void OnPressDown(int i)
   {
      switch (i)
      {
       
      }
   }

   public void Sub(int i)
   {
      GameDataManager.Instance.playerData.SubDiamond(i);
   }
}
