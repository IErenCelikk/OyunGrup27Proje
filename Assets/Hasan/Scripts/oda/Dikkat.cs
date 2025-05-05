using UnityEngine;

public class Dikkat : MonoBehaviour
{
    void Update()
    {
        float scale = 1f + Mathf.Sin(Time.time * 2f) * 0.05f;
        transform.localScale = new Vector3(scale, scale, 1f);

    }

}
