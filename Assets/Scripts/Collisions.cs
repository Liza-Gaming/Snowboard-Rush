using UnityEngine;
using UnityEngine.SceneManagement;
public class Collisions : MonoBehaviour
{
    
    [SerializeField] string space;
    [SerializeField] string finish;
    [SerializeField] string avalanche;

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
        if (other.tag == avalanche && enabled)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Destroy(this.gameObject);
        }
    }
}
