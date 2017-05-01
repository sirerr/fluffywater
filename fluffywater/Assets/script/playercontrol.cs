using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fluffywater{

public class playercontrol : MonoBehaviour {

	public bool mousedown = false;
	public bool mousehold =false;
	public watercontrol waterConRef;
	public LayerMask mask;
	void Awake()
	{
		
	}

	void Start () {
		
	}

	void Update () {

		mousedown =  Input.GetMouseButtonDown(0);
		mousehold = Input.GetMouseButton(0);

		if(mousehold && watercontrol.createmakers)
		{
			camRaycast();
		}
	}

	public void camRaycast()
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position,transform.forward,out hit,Mathf.Infinity,mask.value))
		{
		//	print("this is working");
		//	print(hit.point);
			waterConRef.createwater(hit.point);
		}

	}
}
}