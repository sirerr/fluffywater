using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fluffywater{

public class markerAction : MonoBehaviour {

	public ParticleSystem childPS;
	public bool psPlayDone = true;

	public void Awake()
	{
		getChilds();

	}

	public void getChilds()
	{
		childPS = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {

		if(childPS.isPlaying)
			psPlayDone = false;
		else
			psPlayDone = true;
	}

	public void playParticle()
	{
		if(childPS!=null)
		{
			childPS.Play();
		}
	}

	public IEnumerator waiting(float ranTime)
	{
		yield return new WaitForSeconds(ranTime);	
		playParticle();
	}

	public void doCour(float newtime)
	{
		StartCoroutine(waiting(newtime));
	}
}

}