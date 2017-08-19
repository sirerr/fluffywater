using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fluffywater
{

public class controlboxAction : objectAction {

	public Animator anim;
	public watercontrol watercontrolref;
        private AudioSource asource;
	void Awake()
	{
		anim = GetComponent<Animator> ();
            asource = GetComponent<AudioSource>();
	}

	public override void mainAction ()
	{
			if (watercontrol.createmakers) 
			{
				watercontrolref.clearfountain ();
				anim.SetTrigger ("switch");
                StartCoroutine(smallWait());
			}

	}

        IEnumerator smallWait()
        {
            yield return new WaitForSeconds(.4f);
            asource.Play();
            yield return new WaitForEndOfFrame();
            watercontrolref.startWaterProcess();
        }
	}
}
