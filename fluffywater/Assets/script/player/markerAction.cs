using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fluffywater{

public class markerAction : MonoBehaviour {

	public ParticleSystem childPS;
	public bool psPlayDone = true;
    public Color partColor;
        public float audioTime = 3f;
        public AudioClip clip1;
        public AudioClip clip2;
        AudioSource asource;
	public void Awake()
	{
		getChilds();
            asource = GetComponent<AudioSource>();

	}

	public void getChilds()
	{
		childPS = GetComponentInChildren<ParticleSystem>();
        
	}

        public void setColor()
        {

        }
	
	// Update is called once per frame
	void Update () {

            if (childPS.isPlaying)
            {
                psPlayDone = false;
            }

            else
            {
                psPlayDone = true;
            }
			   
	}

	public void playParticle()
	{
        
		if(childPS!=null)
		{
            asource.PlayOneShot(clip2);
          //  StartCoroutine(waiting());
            childPS.Play();
		}
	}

        public IEnumerator waiting()
        {
            yield return new WaitForSeconds(audioTime);
            asource.PlayOneShot(clip2);
        }

 
}

}