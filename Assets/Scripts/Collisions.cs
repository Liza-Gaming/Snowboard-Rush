using UnityEngine;
using UnityEngine.SceneManagement;
public class Collisions : MonoBehaviour
{

    [SerializeField] string space;
    [SerializeField] string finish;
    [SerializeField] string avalanche;
    [SerializeField] string triggerAvalanche;

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