using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//https://www.youtube.com/watch?v=POq1i8FyRyQ&ab_channel=RehopeGames
public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] float remainingTime;

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
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int second = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, second);

    }
    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}