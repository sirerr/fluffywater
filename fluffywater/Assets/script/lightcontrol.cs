using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightcontrol : objectAction {

	public GameObject arealight;
	public GameObject spotlight;
	public GameObject lightbox;


	public override void mainAction ()
	{
		if (arealight.activeSelf) {
			arealight.SetActive (false);
			lightbox.SetActive (true);
			spotlight.SetActive (true);
		} else 
		{

			arealight.SetActive (true);
			lightbox.SetActive (false);
			spotlight.SetActive (false);
		}

	}
}
