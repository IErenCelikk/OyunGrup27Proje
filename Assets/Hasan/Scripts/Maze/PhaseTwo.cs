using UnityEngine;

public class PhaseTwo : MonoBehaviour
{
    [SerializeField] MazeGeneratorWithPrefabs mg;
    [SerializeField] Collider2D portalCollider;
    [SerializeField] GameObject text;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player");
        {
            Debug.Log("Player");
            text.SetActive(true);
            mg.StartBlinkAndMove();
            //collision.gameObject.transform.SetParent(this.gameObject.transform);
            portalCollider.enabled = true;
        }
    }
}
