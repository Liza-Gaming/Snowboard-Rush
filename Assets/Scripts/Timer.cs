using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] float remainingTime;

    // Start is called before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
     void Update()
    {
        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        if (remainingTime < 0)
        {
            ResetLevel();
        }
        remainingTime -=  Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int second = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, second);

    }
    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}