using UnityEngine;

public class ReturnToCamera2 : MonoBehaviour
{
    public Camera cameraToLookAt; // Assign the camera component to this variable in the Inspector
    public float moveSpeed = 100f; // Speed at which the object moves towards the camera
    public float maxRotationAngle = 5f;
    public float fixedDistance = 200f; // Distance to keep the object from the camera
    public actives Act;

    void Update()
    {
        if(Act.moveTo2)
        {
            print("in");
             ReturnToCamera2 objectToCamera = GetComponent<ReturnToCamera2>();

            // If the object is not staying in front of the camera yet, attach the ReturnToCamera script
            if (objectToCamera == null)
            {
                gameObject.AddComponent<ReturnToCamera2>();
                return;
            }

            Vector3 cameraPosition = cameraToLookAt.transform.position;
            Vector3 objectPosition = transform.position;
            Vector3 direction = cameraPosition - objectPosition;
            direction.y = 0f; // Set y component to 0
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxRotationAngle);

            // Calculate the target position of the object based on the camera position and forward vector
            Vector3 targetPosition = cameraPosition + cameraToLookAt.transform.forward * fixedDistance;
            targetPosition.y = objectPosition.y;
            // Move the object towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
       
    }
}
