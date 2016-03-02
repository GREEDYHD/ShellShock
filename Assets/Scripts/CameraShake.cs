using UnityEngine;
using System.Collections;
namespace ShellShock
{

    public class CameraShake : MonoBehaviour
    {

        public float shakeTimer; //Time the shake lasts
        public float shakeIntesity;//Intensity of the shake
        private Vector3 cameraStartPos;
        // Use this for initialization
        void Start()
        {
            cameraStartPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                shakeCamera(0.1f, 1.0f); //power, duration
            }

            if (shakeTimer >= 0)
            {
                Vector2 shakePosition = Random.insideUnitCircle * shakeIntesity; //Circle that has a 1 unit radius and picks a random x,y value that the camera moves to
                transform.position = new Vector3(transform.position.x + shakePosition.x, transform.position.y + shakePosition.y, transform.position.z); //updates camera position with the insideUnitCircle offset
                shakeTimer -= Time.deltaTime;
            }
            if (shakeTimer <= 0)
            {
                transform.position = cameraStartPos;

            }
        }

        public void shakeCamera(float shakePower, float shakeDuration)
        {
            shakeIntesity = shakePower;
            shakeTimer = shakeDuration;
        }
    }
}
