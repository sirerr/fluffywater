using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace fluffywater
{
    public class watercontrol : MonoBehaviour
    {
        public static bool createmakers = true;
    //    public bool startmaking = true;

        //water objectlist
        public List<GameObject> waterobjs = new List<GameObject>();
        public List<markerAction> markerRefs = new List<markerAction>();
        // water obj
        public GameObject sprinkleObj;
        //water maker button
        public Button makerButton;
        private ColorBlock makerblock;
        //limit of watermakers
        public int makerMax = 20;
        public int makerCounter = 0;
        //
        private Vector3 tempPos;
        public float disMax = .5f;
        public bool firstTime = true;
        //random time value for emissions
        public float particleTimeLimit;
        //default wait time
        public float defaultPlayWaitTime = 3f;
        public Color newRanColor;

        // animation control
        public Animator creatBallAnim;
        public Animator playBallAnim;
        public Animator SequenceAnim;
        private bool isPlaying = false;
        //collider
        public Collider col;
        public float TimeWaitBetweenSprouts = 1.5f;

        public void Awake()
        {
            startWaterProcess();
        }

        public void clearfountain()
        {
            isPlaying = false;
            //maker button reset
            makerButton.interactable = true;
            createmakers = false;
            firstTime = true;
            makerCounter = 0;
            creatBallAnim.enabled = true;
            for (int i = waterobjs.Count - 1; i >= 0; i--)
            {
                Destroy(waterobjs[i].gameObject);

            }
            waterobjs.Clear();
            markerRefs.Clear();
            col.enabled = false;
            if(SequenceCor!=null)
                StopCoroutine(SequenceCor);

        }

        public void RandomEmitTime()
        {
            if (createmakers)
            {
                for (int i = 0; i < waterobjs.Count; i++)
                {
                    float rantime = Random.Range(.5f, particleTimeLimit);
                    //	markerRefs[i].doCour(rantime);
                }
            }
        }

        public void defaultPlay()
        {
            isPlaying = true;
         //   print(isPlaying);
            if (createmakers && waterobjs.Count >= 1)
            {
                for (int i = 0; i < waterobjs.Count; i++)
                {
                    if (markerRefs[i].psPlayDone && makerCounter != 0)
                    {
                        RandomColorPart ran = waterobjs[i].GetComponent<RandomColorPart>();
                        ran.ranColor(newRanColor);
                        markerRefs[i].playParticle();
                    }
                }

            }
            StartCoroutine(defaultPlayWait());
        }

        IEnumerator defaultPlayWait()
        {
            yield return new WaitForSeconds(defaultPlayWaitTime);
            isPlaying = false;
        }

        Coroutine SequenceCor;
        public void SequencePlay()
        {
            isPlaying = true;
            SequenceCor = StartCoroutine(Sequence());
        }

        IEnumerator Sequence()
        {
            if (createmakers && waterobjs.Count >= 1)
            {
                for (int i = 0; i < waterobjs.Count; i++)
                {
                    yield return new WaitForSeconds(TimeWaitBetweenSprouts);
                    if (markerRefs[i].psPlayDone && markerRefs[i] != null) 
                    {
                        RandomColorPart ran = waterobjs[i].GetComponent<RandomColorPart>();
                        ran.ranColor(newRanColor);
                        markerRefs[i].playParticle();
                    }
                }

            }
            isPlaying = false;
        }

        public void RandomColor()
        {
            for (int i = 0; i < waterobjs.Count; i++)
            {
                RandomColorPart ran = waterobjs[i].GetComponent<RandomColorPart>();
                ran.ranColor(newRanColor);
            }
        }

        public void startWaterProcess()
        {
            createmakers = true;
            col.enabled = true;

        }

        public void Update()
        {
            if (waterobjs.Count >= 1 && !isPlaying)
            {
                playBallAnim.enabled = true;
                SequenceAnim.enabled = true;
            }
            else
            {
                playBallAnim.enabled = false;
                SequenceAnim.enabled = false;
            }
        }


        public void createwater(Vector3 pos)
        {
            //	print("working");

            if (firstTime)
            {
                firstTime = false;
                tempPos = pos;
                // make object
                GameObject wawa = Instantiate(sprinkleObj, tempPos, sprinkleObj.transform.rotation) as GameObject;
                waterobjs.Add(wawa);
                markerRefs.Add(wawa.GetComponent<markerAction>());
                // make object end
                makerCounter++;
                //	print("make the first one");
            }
            else
            {
                float dis = Vector3.Distance(tempPos, pos);
                if (dis > disMax && makerCounter <= makerMax)
                {
                    tempPos = pos;
                    //	print("make point " + makerCounter);
                    // make object
                    GameObject wawa = Instantiate(sprinkleObj, tempPos, sprinkleObj.transform.rotation) as GameObject;
                    waterobjs.Add(wawa);
                    markerRefs.Add(wawa.GetComponent<markerAction>());
                    // make object end
                    makerCounter++;

                }
            }
        }
    }
}