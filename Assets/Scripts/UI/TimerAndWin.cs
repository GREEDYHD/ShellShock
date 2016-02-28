using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerAndWin : MonoBehaviour
{
    public float roundLength = 60f;
    public Text timerText;
    public bool gamePaused;

    // Update is called once per frame
    void Update()
    {
        if (gamePaused == false)
        {
            roundLength -= Time.deltaTime;
        }

        string[] timeArr;
        timeArr = roundLength.ToString("F2").Split('.');

        timerText.text = timeArr[0] + ":" + timeArr[1];

        if (roundLength <= 0)
        {
            EndGame();
        }

    }

    void EndGame()
    {
        //Call appropriate function ();
    }
}