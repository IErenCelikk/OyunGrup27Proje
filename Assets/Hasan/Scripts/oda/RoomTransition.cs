using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public Transform cameraTransform;  // Kameran?n transform'u
    public float transitionSpeed = 5f; // Geçi? h?z?
    public Vector3 targetPosition;    // Hedef odan?n pozisyonu

    private bool isTransitioning = false;

    void Update()
    {
        // E?er geçi? yap?l?yorsa, kameray? yeni pozisyona kayd?r
        if (isTransitioning)
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetPosition, transitionSpeed * Time.deltaTime);

            // Geçi? tamamland???nda
            if (Vector3.Distance(cameraTransform.position, targetPosition) < 0.1f)
            {
                isTransitioning = false;
                cameraTransform.position = targetPosition;
            }
        }
    }

    // Geçi? ba?latmak için bu fonksiyon ça?r?lacak
    public void StartTransition(Vector3 newPosition)
    {
        targetPosition = newPosition;
        isTransitioning = true;
    }
}
