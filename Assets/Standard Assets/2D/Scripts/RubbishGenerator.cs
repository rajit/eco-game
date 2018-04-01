using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishGenerator : MonoBehaviour {

	//public Renderer terrain;
	public int numberOfObjects; // number of objects to place
	private int currentObjects; // number of placed objects
	public GameObject objectToPlace; // GameObject to place
	private int terrainWidth; // terrain size (x)
	private int terrainLength; // terrain size (z)
	private int terrainPosX; // terrain position x
	private int terrainPosY; // terrain position z

	// Use this for initialization
	void Start () {

		Renderer terrain = GetComponent<Renderer> ();
		// terrain size x
		terrainWidth = (int)(terrain.bounds.max.x - terrain.bounds.min.x);
		// terrain size z
		terrainLength = (int)(terrain.bounds.max.y - terrain.bounds.min.y);
		// terrain x position
		terrainPosX = (int)terrain.transform.position.x;
		// terrain z position
		terrainPosY = (int)terrain.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		// generate objects
		if (currentObjects <= numberOfObjects) {
			// generate random x position
			int posx = Random.Range (terrainPosX, terrainPosX + terrainWidth);
			// generate random z position
			int posy = Random.Range (terrainPosY, terrainPosY + terrainLength);
			// get the terrain height at the random position
			//float posy = Terrain.activeTerrain.SampleHeight (new Vector3 (posx, 0, posz));
			// create new gameObject on random position
			GameObject newObject = (GameObject)Instantiate (objectToPlace, new Vector3 (posx, posy, objectToPlace.transform.position.z), Quaternion.identity);
			currentObjects += 1;
		}

		if(currentObjects == numberOfObjects)
		{
			Debug.Log("Generate objects complete!");
		}
	}
}
