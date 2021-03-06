﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fluffywater{

public class playercontrol : MonoBehaviour {

	public bool mousedown = false;
	public bool mousehold =false;
	public watercontrol waterConRef;
	public LayerMask mask;
    private playerRecAction playerRecActionRef;
	void Awake()
	{
            playerRecActionRef = GetComponentInChildren<playerRecAction>();
	}

	void Start () {
		
	}

	void Update () {

		
		mousedown =  Input.GetMouseButtonDown(0);
		mousehold = Input.GetMouseButton(0);
        camRaycast();
        }

	public void camRaycast()
	{
		RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, mask.value))
            {
                playerRecActionRef.ChangeRecLook();
                if (mousehold && watercontrol.createmakers && hit.collider.CompareTag("waterobj"))
                {
                    waterConRef.createwater(hit.point);
                }

                if (mousedown)
                {
                    if (hit.transform.GetComponent<objectAction>() != null)
                    {
                        objectAction objA = hit.transform.GetComponent<objectAction>();

                        objA.mainAction();
                    }
                }


            }
            else
            {
                playerRecActionRef.ChangeBack();
            }

	}
}
}