using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class watercontrol : MonoBehaviour {
	public static bool createmakers = false;
	//water objectlist
	public List<GameObject> waterobjs = new List<GameObject>();
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

		for(int i=0;i<=makerMax;i++)
		{
			Destroy(waterobjs[i].gameObject);

		}
		waterobjs.Clear();
	}

	public void startWaterProcess()
	{
		createmakers = true;
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
			// make object end
			makerCounter++;
		//	print("make the first one");
		}else
		{
			float dis = Vector3.Distance(tempPos,pos);
			if(dis>disMax && makerCounter<=makerMax)
			{
				tempPos =pos;
				print("make point " + makerCounter);
				// make object
				GameObject wawa = Instantiate(sprinkleObj,tempPos,sprinkleObj.transform.rotation)as GameObject;
				waterobjs.Add(wawa);
				// make object end
				makerCounter++;

			}
		}
	}
}
