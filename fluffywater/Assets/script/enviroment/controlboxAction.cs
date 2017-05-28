using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fluffywater
{

public class controlboxAction : objectAction {

	public Animator anim;
	public watercontrol watercontrolref;

	void Awake()
	{
		anim = GetComponent<Animator> ();
	
	}

	public override void mainAction ()
	{
			if (watercontrol.createmakers) 
			{
				watercontrolref.clearfountain ();
				anim.SetTrigger ("switch");
			}

	}
	}
}
