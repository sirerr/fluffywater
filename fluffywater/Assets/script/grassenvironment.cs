using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fluffywater{

public class grassenvironment : MonoBehaviour {

	public List <GameObject> grasses = new List<GameObject>();
	public int grassAmount = 40;
	private Bounds colBounds;

	void Awake()
	{
		colBounds = GetComponent<Collider>().bounds;

		for(int i=0; i<grassAmount;i++)
		{
			int grasschoice = Random.Range(0,grasses.Count);
			float ranX = Random.Range(colBounds.min.x,colBounds.max.x);
			float ranY = Random.Range(colBounds.min.y,colBounds.max.y);
			float ranZ = Random.Range(colBounds.min.z,colBounds.max.z);
			Vector3 vec = new Vector3(ranX,ranY,ranZ);

			GameObject grassobj = Instantiate(grasses[grasschoice],vec,grasses[grasschoice].transform.rotation )as GameObject;
				Vector3 scale = grasses [grasschoice].transform.localScale;
				grassobj.transform.localScale = scale;
		}

	
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
}
