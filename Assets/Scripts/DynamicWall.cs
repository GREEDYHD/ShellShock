using UnityEngine;
using System.Collections;

public class DynamicWall : MonoBehaviour {
	public GameObject[] dynamicWalls;
	// Use this for initialization
	void Start()
	{

	}

	void Update()
	{
		if (Input.GetButton ("Fire2")) 
		{
			Walls();
		}
	}

	void Walls()
	{
		for(int i = 0; i > 4; i++)
		{
			Random.Range (0,dynamicWalls.Length);
		}
	}
}
