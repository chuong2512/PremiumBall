using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInfo : MonoBehaviour
{
	public string ballTag;
	// Start is called before the first frame update
	public string GetTag()                  { return ballTag; }
	public void   SetTag(string newMessage) { ballTag=newMessage; }

	public Material[]   skins;
	public MeshRenderer MeshRenderer;

	void OnValidate() { MeshRenderer=GetComponent<MeshRenderer>(); }

	void Start()
	{
		if(skins is {Length: >0})
			MeshRenderer.sharedMaterial=skins[GameDataManager.Instance.playerData.skinID];
	}
}
