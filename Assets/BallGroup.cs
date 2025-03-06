using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum State
{
   Using, Bought, Not
}

public class BallGroup : Jackal.Singleton<BallGroup>
{
   public BuyBallButton[] buttons;

   void Start()
   {
      SetData();
   }
   void SetData()
   {
      
   }
}
