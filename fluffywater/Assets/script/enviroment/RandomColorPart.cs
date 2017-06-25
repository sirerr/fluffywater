using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fluffywater{

public class RandomColorPart : MonoBehaviour {

	private ParticleSystem childPart;

	private Color newcolor;

	public	void ranColor(Color chosenColor)
	{//	print("new color");
		newcolor = chosenColor;
		childPart = GetComponentInChildren<ParticleSystem>();
		var mainset = childPart.main;
		var col = childPart.colorOverLifetime;
		col.enabled = true;

		Gradient grad = new Gradient();
		grad.SetKeys( new GradientColorKey[] {new GradientColorKey(newcolor,0.0f)}, new GradientAlphaKey[]{new GradientAlphaKey(.15f,0.0f)});
		mainset.startColor = grad;
		col.color =grad;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
}