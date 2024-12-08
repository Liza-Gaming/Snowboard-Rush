using System.Collections;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    public GameObject[] spheres; // Array to hold sphere game objects
    public float delay = 10f;    // Delay before activating spheres


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player has the tag "Player"
        {
            // Call the method to activate the avalanche
            StartAvalanche();
        }
    }

    public void StartAvalanche()
    {
        StartCoroutine(ActivateSpheresAfterDelay());
    }

    private IEnumerator ActivateSpheresAfterDelay()
    {
        yield return new WaitForSeconds(0);
        // Immediate or delayed sphere activation logic can be customized here
        foreach (GameObject sphere in spheres)
        {
            sphere.SetActive(true);
        }
    }
}