using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerAndWin : MonoBehaviour {
	
	
	public float  timer ;
	
	public float timepassed;
	
	public Text TimerFormat;
	
	public bool startTimer = false;
	
	public bool GameOver = false;
	
	public Text WinText;
	
	
	// Use this for initialization
	void Start () {
		
		startTimer = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (startTimer == true) {
			
			timer = 60.0f;
			timepassed += Time.deltaTime;
			
			
			System.TimeSpan t = (System.TimeSpan.FromSeconds (timer)) - (System.TimeSpan.FromSeconds (timepassed));
			TimerFormat.text = string.Format ("{0:D2}", t.Seconds);
			
			if ( t.Seconds <= 0 )
			{
				TimerFormat.text = "00";
				GameOver = true;
				timepassed = 60;
				
			}
		}
		
		
		if (GameOver == true) {
			WinText.gameObject.SetActive(true);
		}
	}
}

