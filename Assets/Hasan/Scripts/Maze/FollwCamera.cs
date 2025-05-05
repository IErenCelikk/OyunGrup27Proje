using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public float waitBeforeFollow = 1f; 

    private Vector3 velocity = Vector3.zero;
    private float timer = 0f;
    private bool shouldFollow = false;

    private void Start()
    {
        target = null;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (!shouldFollow && timer >= waitBeforeFollow)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
                shouldFollow = true;
            }
        }
    }

    private void LateUpdate()
    {
        if (shouldFollow && target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
