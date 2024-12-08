using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Manages the player's collisions with various objects in the game.
 * Handles scoring, level transitions, and player destruction.
 */
public class Collisions : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Tag for objects.")]
    private string space;

    [SerializeField]
    [Tooltip("Tag for objects.")]
    private string finish;

    [SerializeField]
    [Tooltip("Tag for objects.")]
    private string avalanche;

    // Called when another collider enters the trigger collider attached to this object
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == space && enabled)
        {
            ScoreManager.instance.AddPoint();
            Destroy(other.gameObject);
        }
        if (other.tag == finish && enabled)
        {
            SceneManager.LoadScene(1);
            Destroy(other.gameObject);
        }
        if (other.tag == avalanche)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}