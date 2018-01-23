using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;
using System.Collections;

namespace CompleteProject
{
    public class PlayerMovement : MonoBehaviour
    {
        public float movementSpeed = 2f;            // The speed that the player will move at.
        public float mouseSensivity = 2f;            // The speed that the player will move at.


        Vector3 movement;                   // The vector to store the direction of the player's movement.
        Animator anim;                      // Reference to the animator component.
        Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
#if !MOBILE_INPUT
        int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
        float camRayLength = 100f;          // The length of the ray from the camera into the scene.
#endif

        Transform offsetTransform;
        Vector3 offset;


        float rotX;
        float rotY;
        float moveV;
        float moveH;

        private IEnumerator rotate()
        {

            rotX = Input.GetAxis("Mouse X") * mouseSensivity;

            transform.Rotate(0, rotX, 0);

            Quaternion rot = transform.rotation;
            rot = Quaternion.Euler(1.5f, rot.eulerAngles.y, rot.eulerAngles.z);

            Camera.main.transform.rotation = rot;

            yield return null;
        }


        private IEnumerator move()
        {
            Vector3 pos = transform.position;// +offset;
            pos.y = 1;
            Camera.main.transform.position = pos;

            moveV = Input.GetAxis("Vertical") * movementSpeed;
            moveH = Input.GetAxis("Horizontal") * movementSpeed;

            Vector3 movement = new Vector3(moveH, 0, moveV);


            movement = transform.rotation * movement;
            playerRigidbody.MovePosition(transform.position + movement);
            transform.position = playerRigidbody.position;

            yield return null;
        }



        private void rotatePlayer()
        {
            rotX = Input.GetAxis("Mouse X") * mouseSensivity;

            transform.Rotate(0, rotX, 0);

            Quaternion rot = transform.rotation;
            rot = Quaternion.Euler(1.5f, rot.eulerAngles.y, rot.eulerAngles.z);

            Camera.main.transform.rotation = rot;
        }


        private void movePlayer()
        {
            Vector3 pos = transform.position;// +offset;
            pos.y = 1;
            Camera.main.transform.position = pos;

            moveV = Input.GetAxis("Vertical") * movementSpeed;
            moveH = Input.GetAxis("Horizontal") * movementSpeed;

            Vector3 movement = new Vector3(moveH, 0, moveV);


            movement = transform.rotation * movement;
            playerRigidbody.MovePosition(transform.position + movement);
            transform.position = playerRigidbody.position;
        }


        void Awake()
        {
#if !MOBILE_INPUT
            // Create a layer mask for the floor layer.
            floorMask = LayerMask.GetMask("Floor");
#endif

            // Set up references.
            anim = GetComponent<Animator>();
            playerRigidbody = GetComponent<Rigidbody>();
        }

        private bool gameEnded = false;

        void FixedUpdate()
        {
            if (TriggerManager.isInRange())
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 300, 300, transform.position.z + 300), 0.01f);
                gameEnded = true;
            }
            if (!gameEnded)
            {
                StartCoroutine("move");
                StartCoroutine("rotate");
            }

        }


        void Move(float h, float v)
        {
            // Set the movement vector based on the axis input.
            movement.Set(h, 0f, v);

            // Normalise the movement vector and make it proportional to the speed per second.
            movement = movement.normalized * movementSpeed * Time.deltaTime;

            // Move the player to it's current position plus the movement.
            playerRigidbody.MovePosition(transform.position + movement);
        }


        void Turning()
        {
#if !MOBILE_INPUT
            // Create a ray from the mouse cursor on screen in the direction of the camera.
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Create a RaycastHit variable to store information about what was hit by the ray.
            RaycastHit floorHit;

            // Perform the raycast and if it hits something on the floor layer...
            if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
            {
                // Create a vector from the player to the point on the floor the raycast from the mouse hit.
                Vector3 playerToMouse = floorHit.point - transform.position;

                // Ensure the vector is entirely along the floor plane.
                playerToMouse.y = 0f;

                // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
                Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);

                // Set the player's rotation to this new rotation.
                playerRigidbody.MoveRotation(newRotatation);
            }
#else

            Vector3 turnDir = new Vector3(CrossPlatformInputManager.GetAxisRaw("Mouse X") , 0f , CrossPlatformInputManager.GetAxisRaw("Mouse Y"));

            if (turnDir != Vector3.zero)
            {
                // Create a vector from the player to the point on the floor the raycast from the mouse hit.
                Vector3 playerToMouse = (transform.position + turnDir) - transform.position;

                // Ensure the vector is entirely along the floor plane.
                playerToMouse.y = 0f;

                // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
                Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);

                // Set the player's rotation to this new rotation.
                playerRigidbody.MoveRotation(newRotatation);
            }
#endif
        }


        void Animating(float h, float v)
        {
            // Create a boolean that is true if either of the input axes is non-zero.
            bool walking = h != 0f || v != 0f;

            // Tell the animator whether or not the player is walking.
            anim.SetBool("IsWalking", walking);
        }
    }
}