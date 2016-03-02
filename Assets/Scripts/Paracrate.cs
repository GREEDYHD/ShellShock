using UnityEngine;
using System.Collections;
namespace ShellShock
{
    public class Paracrate : MonoBehaviour
    {

        public GameObject paracrateObj;
        public Vector2 tempDropCoordinates;
        public float leftXBoundary, rightXBoundary, topYBoundary, bottomYBoundary;
        private bool flyby = false;
        public float flybySpeed;
        public bool ammoDropped;

        public float minTime = 5.0f;
        public float maxTime = 9.0f;
        public bool isHeliSpawning = false;

        // Use this for initialization
        void Start()
        {
            ammoDropped = false;
            tempDropCoordinates = new Vector2(0, -7);
        }

        // Update is called once per frame
        void Update()
        {
            if (!isHeliSpawning)
            {
                isHeliSpawning = true;
                flyby = !flyby;
                StartCoroutine(HeliSpawner(Random.Range(minTime, maxTime))); //the helicopter will now spawn in a random range between 5 and 9 secs
                transform.position = new Vector3(39f/*Random.Range(34f,55f)*/, Random.Range(-6f, 10f), 0.2f); //randomize the spawning position of the helicopte

                //Debug.Log("asda");
            }
            //if (Input.GetKeyDown(KeyCode.T)) 
            //{
            //	flyby = !flyby;
            //          Debug.Log("asda");
            //}

            if (flyby)
            {
                AmmoDrop();
            }
        }

        public void AmmoDrop()
        {
            transform.Translate(-Vector2.right * flybySpeed * Time.deltaTime);
            if (transform.position.x > -0.1 && transform.position.x < 0.1)
            {
                //Debug.Log("Drop");
                Instantiate(paracrateObj, transform.position, Quaternion.identity);
            }
        }

        IEnumerator HeliSpawner(float seconds)
        {

            ammoDropped = false;
            tempDropCoordinates = new Vector2(0, -7); //to be changed
            yield return new WaitForSeconds(seconds);
            isHeliSpawning = false;
        }
    }
}
