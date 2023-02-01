using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float spawnTime = 5f;
	public float spawnDelay = 3f;
	public float range = 0f;
	public int maxObjects;
	public GameObject[] objects;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn",spawnDelay,spawnTime);
	}

	void Spawn(){

		GameObject[] currentObjects = GameObject.FindGameObjectsWithTag(objects[0].tag);

		if(currentObjects.Length < maxObjects)
		{

			float xposition = Random.Range(transform.position.x - range, transform.position.x + range);

		int objectIndex = Random.Range(0,objects.Length);
			Instantiate(objects[objectIndex],new Vector3(xposition,transform.position.y,transform.position.z),transform.rotation);
		}
	}
}
