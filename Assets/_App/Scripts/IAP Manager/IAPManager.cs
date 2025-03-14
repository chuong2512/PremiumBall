using System;
using CI.WSANative.Common;
using CI.WSANative.Store;
using Jackal;

public class IAPManager : PersistentSingleton<IAPManager>
{
    public static Action OnPurchaseSuccess;

    private bool _isBuyFromShop;
    void Awake()
    {
        WSANativeCore.Initialise();
    }
   
    //store id get from microsoft partner 
    public void BuyProductID(string storeid, int points = 0)
    {
        WSANativeStore.RequestPurchase(storeid, result =>
        {
            UnityEngine.Debug.Log(result.Status);
            if(result.Status == WSAStorePurchaseStatus.Succeeded)
            {
                // do something here to add point value
                OnPurchaseSuccess?.Invoke();
            }
        });
    }
}