using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


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
            birdcolor = mat.color;        
                        
        }

        // Use this for initialization
        void Start()
        {
//            EventTrigger trigger = GetComponent<EventTrigger>();
//            EventTrigger.Entry entry = new EventTrigger.Entry();
//            entry.eventID = EventTriggerType.PointerEnter;
//            entry.callback.AddListener((PointerEventData) => { mainAction(); });
//            trigger.triggers.Add(entry);
//          
        }

        // Update is called once per frame
        public override void Update()
        {

        }

        public override void mainAction()
        {
			waterControlRef.newRanColor = birdcolor;
			waterControlRef.RandomColor ();
        }
    }
}