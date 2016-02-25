using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerAndWin : MonoBehaviour
{
    public float roundLength = 60f;
	public Text timerText;
	public bool gamePaused;
 


    // Use this for initialization
    void Start()
    {

       

    }

    // Update is called once per frame
    void Update()
    {
		if (gamePaused == false)
		{
			roundLength -= Time.deltaTime;
		}
		timerText.text = roundLength.ToString("F2") ;

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

