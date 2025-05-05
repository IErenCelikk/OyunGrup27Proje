using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public Transform cameraTransform;  
    public float transitionSpeed = 5f; 
    public Vector3 targetPosition;    
    private bool isTransitioning = false;

    [SerializeField] Vector3 FixedTransform;

    void OnMouseDown()
    {
        if (cameraTransform.position == FixedTransform)
        {
            StartTransition(targetPosition);
        }
    }

    void Update()
    {
        if (isTransitioning)
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPosition, transitionSpeed * Time.deltaTime);

            if (Vector3.Distance(cameraTransform.position, targetPosition) < 0.1f)
            {
                isTransitioning = false;
                cameraTransform.position = targetPosition;
            }
        }
    }

    public void StartTransition(Vector3 newPosition)
    {
        targetPosition = newPosition;
        isTransitioning = true;
    }
}