using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;            // The position that that camera will be following.
        public float smoothing = 5f;        // The speed with which the camera will be following.


        Vector3 offset;                     // The initial offset from the target.

        float rotX;
        float rotY;
        float moveR;
        float moveL;



        void Start()
        {
            // Calculate the initial offset.
            offset = transform.position - target.position;

        }


        void FixedUpdate()
        {

            Camera.main.transform.position = target.position+offset;
              Camera.main.transform.rotation = target.rotation;

            moveL = Input.GetAxis("Vertical") * 2f;
            moveR = Input.GetAxis("Horizontal") * 2f;

            rotX = Input.GetAxis("Mouse X") * 2f;
            rotY = Input.GetAxis("Mouse Y") * 2f;

            Vector3 movement = new Vector3(0, moveR, moveL);

            transform.Rotate(0, rotX, 0);

            movement = transform.rotation * movement;

            Camera.main.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

            target.transform.position = movement;

            // Create a postion the camera is aiming for based on the offset from the target.
            // Vector3 targetCamPos = target.position + offset;

            // Smoothly interpolate between the camera's current position and it's target position.
            // transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }
}