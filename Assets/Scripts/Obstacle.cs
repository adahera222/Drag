using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	public void  OnTriggerEnter(Collider collider)
	{
		Debug.LogWarning("HIT");
		if(collider.GetComponent<Car>() != null)
			collider.GetComponent<Car>().Hit();
	}
}
