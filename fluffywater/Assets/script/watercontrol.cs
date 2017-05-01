﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace fluffywater{

public class watercontrol : MonoBehaviour {
	public static bool createmakers = false;
	//water objectlist
	public List<GameObject> waterobjs = new List<GameObject>();
	public List<markerAction> markerRefs = new List<markerAction>();
	// water obj
	public GameObject sprinkleObj;
	//water maker button
	public Button makerButton;
	private ColorBlock makerblock;
	//limit of watermakers
	public int makerMax = 20;
	public int makerCounter =0;
	//
	private Vector3 tempPos;
	public float disMax = .5f;
	public bool firstTime = true;
	//random time value for emissions
	public float particleTimeLimit;

	public void Awake()
	{
		makerblock = makerButton.colors;

	}

	public void clearfountain()
	{
		//maker button reset
		makerButton.interactable = true;
		createmakers = false;
		firstTime =true;
		makerCounter = 0;

		for(int i=waterobjs.Count-1;i>=0;i--)
		{
			Destroy(waterobjs[i].gameObject);

		}
		waterobjs.Clear();
		markerRefs.Clear();
	}

	public void RandomEmitTime()
	{
		if(createmakers)
		{
			for(int i=0;i<waterobjs.Count;i++)
			{
				float rantime = Random.Range(.5f,particleTimeLimit);
				markerRefs[i].doCour(rantime);
			}
		}
	}

	public void defaultPlay()
	{
		if(createmakers)
		{
			for(int i=0;i<waterobjs.Count;i++)
			{
				if(markerRefs[i].psPlayDone)
				{
					markerRefs[i].playParticle();
				}
			}

		}

	}

	public void RandomColor()
	{


		Color col = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
		for(int i=0;i<waterobjs.Count;i++)
		{
			RandomColorPart ran = waterobjs[i].GetComponent<RandomColorPart>();
			ran.ranColor(col);
		}
	}

	public void startWaterProcess()
	{
		createmakers = true;
		StartCoroutine(notInteract());
	}

	IEnumerator notInteract()
	{
		yield return new WaitForSeconds(1f);
		makerButton.interactable = false;
	}
	public void createwater(Vector3 pos)
	{
	//	print("working");

			if(firstTime)
			{
			firstTime = false;
			tempPos = pos;
			// make object
			GameObject wawa = Instantiate(sprinkleObj,tempPos,sprinkleObj.transform.rotation)as GameObject;
			waterobjs.Add(wawa);
			markerRefs.Add(wawa.GetComponent<markerAction>());
			// make object end
			makerCounter++;
		//	print("make the first one");
		}else
		{
			float dis = Vector3.Distance(tempPos,pos);
			if(dis>disMax && makerCounter<=makerMax)
			{
				tempPos =pos;
			//	print("make point " + makerCounter);
				// make object
				GameObject wawa = Instantiate(sprinkleObj,tempPos,sprinkleObj.transform.rotation)as GameObject;
				waterobjs.Add(wawa);
				markerRefs.Add(wawa.GetComponent<markerAction>());
				// make object end
				makerCounter++;

			}
		}
	}
}
}