using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public static class GameAction
{
	public static Action<int> updateSkinAction;
}

public enum BallSkinState
{
	Equipped,
	Lock,
	Bought
}

public class BuyBallButton : MonoBehaviour
{
	public Button _equipBtn;
	public Button _buyBtn;
	public Button _equipped;

	public int SkinID=0;

	void Start()
	{
		GameAction.updateSkinAction-=OnUpdateSkin;
		GameAction.updateSkinAction+=OnUpdateSkin;

		SetStateSkin();

		_equipBtn.onClick.AddListener(EquipSkin);
		_buyBtn.onClick.AddListener(BuySkin);
	}

	void OnDestroy() { GameAction.updateSkinAction-=OnUpdateSkin; }

	void SetStateSkin()
	{
		var skinID=GameDataManager.Instance.playerData.skinID;

		var containSkin=GameDataManager.Instance.playerData.skins.Contains(SkinID);

		if(!containSkin)
		{
			SetState(BallSkinState.Lock);
			return;
		}

		if(this.SkinID==skinID)
		{
			SetState(BallSkinState.Equipped);
		}
		else
		{
			SetState(BallSkinState.Bought);
		}
	}

	void OnUpdateSkin(int skinID) { SetStateSkin(); }

	public void BuySkin()
	{
		GameDataManager.Instance.playerData.SubDiamond(100);

		GameDataManager.Instance.playerData.AddSkin(SkinID);

		SetState(BallSkinState.Bought);

		GameAction.updateSkinAction?.Invoke(SkinID);
	}
	public void EquipSkin()
	{
		GameDataManager.Instance.playerData.SetSkinID(SkinID);

		SetState(BallSkinState.Equipped);

		GameAction.updateSkinAction?.Invoke(SkinID);
		GameAction.updateSkinAction?.Invoke(SkinID);
	}

	public void EquipSkin(int skinID) { GameDataManager.Instance.playerData.SetSkinID(SkinID); }

	public void SetState(BallSkinState state)
	{
		_equipped.gameObject.SetActive(state==BallSkinState.Equipped);
		_buyBtn.gameObject.SetActive(state==BallSkinState.Lock);
		_equipBtn.gameObject.SetActive(state==BallSkinState.Bought);
	}
}
