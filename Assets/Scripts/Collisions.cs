using UnityEngine;
using UnityEngine.SceneManagement;
public class Collisions : MonoBehaviour
{
    
    [SerializeField] string space;
    [SerializeField] string finish;

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
    }
}
