﻿using UnityEngine;
using System.Collections;

public class DynamicWallManager : MonoBehaviour {

	public GameObject[] DynamicWallsList;
	public DynamicWallScript wallScript;

	// Use this for initialization
	void Start () 
	{
		DynamicWallsList = GameObject.FindGameObjectsWithTag("Dynamic");
		wallScript = GetComponent<DynamicWallScript> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void RaiseAllWalls()
	{

	}

	public void DropAllWalls()
	{
		for (int i = 0; i < DynamicWallsList.Length; i++) 
		{

		}
	}

	public void RandomWallDrop()
	{

	}
}
