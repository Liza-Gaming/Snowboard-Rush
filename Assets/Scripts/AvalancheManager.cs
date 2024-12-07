using System.Collections;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    public GameObject[] spheres; // Array to hold sphere game objects
    public float delay = 10f;    // Delay before activating spheres

    void Start()
    {
        // Start a coroutine that waits and then activates the spheres
        StartCoroutine(ActivateSpheresAfterDelay());
    }

    private IEnumerator ActivateSpheresAfterDelay()
    {
        // Wait for the specified duration (10 seconds here)
        yield return new WaitForSeconds(delay);

        // Loop through each sphere in the array and activate it
        foreach (GameObject sphere in spheres)
        {
            sphere.SetActive(true);
        }
    }
}