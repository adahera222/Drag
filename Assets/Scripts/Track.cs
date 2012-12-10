using UnityEngine;
using System.Collections;

public class Track : MonoBehaviour {
	public Obstacle obstacle;
	public GameObject obstaclePrefab;

	public float ObstaclePlacementChance = 0.3f;
	
	void Start () {
		if(UnityEngine.Random.Range(0f, 1f) < ObstaclePlacementChance)
		{
			PlaceObstacle();
		}
	}
	
	void PlaceObstacle()
	{
		GameObject go = (GameObject)Instantiate(obstaclePrefab,transform.position + Vector3.forward*UnityEngine.Random.Range(0f, 1f) * 25f,Quaternion.identity);
		obstacle = go.GetComponent<Obstacle>();
	}
}
