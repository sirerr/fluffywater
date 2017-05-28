using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace fluffywater
{

    public class birdMovement : MonoBehaviour
    {
        public GameObject floor;
        private Bounds grassFloorBounds;
        private Vector3 randomPos;

        public NavMeshAgent agent;

        private Animator anim;
        //test
        public float waitTime = 10f;
        public float randomRangeLimit = 2f;
        private Vector3 startFlightPos;
        public float NotGroundmin = 5f;
        public float NotGroundmax = 10f;

        //leave ground
        public bool inFlight = false;
        private List<Transform> flightstops = new List<Transform>();
        public Transform parentstop;
        private bool isOnGround = true;

        //test
        public void Awake()
        {
            //   grassFloorBounds = floor.GetComponent<Collider>().bounds;
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
            
            inFlight = anim.GetBool("flying");
        }

        public void flyToNewPoint()
        {
            startFlightPos = transform.position;

        }


        // Use this for initialization
        void Start()
        {
        
            StartCoroutine(nextSpot());
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 temp = agent.destination;
            temp.y = transform.position.y;
            float dis = Vector3.Distance(transform.position, temp);
            anim.SetFloat("distance", dis);
         //   print(dis);
        }

        IEnumerator nextSpot()
        {
            if (!inFlight || isOnGround)
            {
                FindNewPoint();
                float possibleHead = Random.Range(0f, 1f);
                if (possibleHead < .3f)
                {
                    anim.SetTrigger("headmove");
                }
                float possiblepoke = Random.Range(0f, 1f);
                if (possiblepoke < .5f)
                {
                    anim.SetTrigger("poke");
                }
                float newSpotTime = Random.Range(NotGroundmin, NotGroundmax);
                yield return new WaitForSeconds(newSpotTime);
                StartCoroutine(nextSpot());
            }
            else
            {
                float newSpotTime = Random.Range(NotGroundmin, NotGroundmax);
                yield return new WaitForSeconds(newSpotTime);



            }

        }

        public void FindNewPoint()
        {
            float lookrange = Random.Range(3, randomRangeLimit);
            Vector3 randompoint = transform.position + Random.insideUnitSphere * lookrange;
            NavMeshHit hit;

            if (NavMesh.SamplePosition(randompoint, out hit, randomRangeLimit, NavMesh.AllAreas))
            {
                agent.destination = hit.position;
            }
            else
            {
                FindNewPoint();
            }
        }
    }
    
}
