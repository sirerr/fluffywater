using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("script/playerRecticle")]
public class playerRecAction : MonoBehaviour {
    private GvrReticlePointerImpl playerRecRef;
    public List<Material> cursorMats = new List<Material>();

	// Use this for initialization
	void Start () {
        playerRecRef.OnStart();
        UpdateReticleProperties();
       
    }

    void Awake()
    {
        playerRecRef = new GvrReticlePointerImpl();
    }

    public void SetAsMainPointer()
    {
        GvrPointerManager.Pointer = playerRecRef;
    }

    // Update is called once per frame
    void Update () {

        UpdateReticleProperties();
    }

    private void UpdateReticleProperties()
    {
        if (playerRecRef == null)
        {
            return;
        }
       
        playerRecRef.PointerTransform = transform;
    }
}
