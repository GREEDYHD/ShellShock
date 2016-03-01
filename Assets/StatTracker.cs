using UnityEngine;
using System.Collections;

public class StatTracker : MonoBehaviour {

	public GameObject p;
	public GameObject acoladeManager;
	Vector3 oldPos;
	float oldValue;

	public float elusiveScore;  //Linked to the acolade, elusive (taken the least damage)
	public float timeSatStill; //Linked to the acolade, squatter
	public float amountOfBullets; //Linked to the acolade, spray and pray
	//Need another script to compare all of the different score
	// Use this for initialization
	void Start () {
		acoladeManager.GetComponent<Acolades> ().statTrackers.Add (this.gameObject);
		elusiveScore = p.GetComponent<Player> ().HPSlider.value;
	}	
	
	// Update is called once per frame
	void Update () {
		oldPos = new Vector3 (0, 0, 0);
		oldValue = p.GetComponent<Player> ().ammoSlider.value;
		if (p.transform.position == oldPos) {
			timeSatStill += Time.deltaTime;
		}
		oldPos = p.transform.position;

		if(p.GetComponent<Player> ().ammoSlider.value <= oldValue)
		{
			amountOfBullets += 1;
		}
	}
}
