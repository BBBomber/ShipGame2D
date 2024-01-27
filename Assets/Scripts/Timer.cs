using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float timer = 0f;

    private bool playerAlive = true;

    public void PlayerDeath()
    {
        playerAlive = false;
    }

    void Update()
    {
        if(playerAlive)
        {
            timer += Time.deltaTime;

            // Format the timer as minutes and seconds
            string minutes = Mathf.Floor(timer / 60).ToString("00");
            string seconds = (timer % 60).ToString("00");

            // Update the TMP text
            timerText.text = "Time: " + minutes + ":" + seconds;
        }
        
       
    }
}