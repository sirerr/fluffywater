using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fluffywater
{

    public class EggLaycontrol : objectAction
    {
        private bool laymode = false;
        public Vector3 pos;
        public Animator birdanim;
        public float flyheight = 2f;
        public override void mainAction()
        {
            if (!laymode)
            {
                laymode = true;
            }
            watercontrol.createmakers = true;


        }

        public override void Update()
        {
            if (laymode)
            {
                // birds dropping eggs to shoot water
            }
        }


    }
}