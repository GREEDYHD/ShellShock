using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace ShellShock
{
    public class TimerAndWin : MonoBehaviour
    {
        public float roundLength = 60f;
        bool isGameRunning = true;

        public Text timerText;
        public bool isGamePaused;

        // Update is called once per frame
        void Update()
        {
            if (!isGamePaused && isGameRunning)
            {
                roundLength -= Time.deltaTime;

                string[] timeArr;
                timeArr = roundLength.ToString("F2").Split('.');

                timerText.text = int.Parse(timeArr[0]) < 10 ? 0 + timeArr[0] + ":" + timeArr[1] : timeArr[0] + ":" + timeArr[1];
            }

            if (roundLength <= 0 && isGameRunning)
            {
                EndGame();
            }
        }

        void EndGame()
        {
            isGameRunning = false;
            timerText.text = "00:00";
            Application.Quit();
        }
    }
}