using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace fluffywater
{

    public class birdAction : objectAction
    {

        public Color birdcolor;
        private Material mat;
        public watercontrol waterControlRef;

        void Awake()
        {
            mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
            mat.color = birdcolor;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        public override void Update()
        {

        }

        public override void mainAction()
        {

        }
    }
}