using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TrackBuilder : MonoBehaviour {
	public GameObject[] tracks;
	public Car car;
	public List<Track> placedTracks;
	public float nextBuildMark;
	public int trackWide = 3;
	public int currentTrackLength = 0;
	public int bundleSize = 10;
	public void Build()
	{
		nextBuildMark = currentTrackLength * 25 + bundleSize / 2 * 25;
		for(int i = 0; i<bundleSize; i++)
		{
			for(int j = 0; j<trackWide; j++)
			{
				GameObject t = (GameObject)Instantiate(tracks[UnityEngine.Random.Range(0, tracks.Length)],new Vector3(j*3f,0,(currentTrackLength+i)*25),Quaternion.identity);
				placedTracks.Add(t.GetComponent<Track>());
			}
			currentTrackLength++;
		}
		
	}

	public void Clean()
	{
		foreach(var o in placedTracks)
		{
			if(o.transform.position.z < nextBuildMark - 25f)
			{
				Destroy(o.gameObject);
			}
		}
	}

	// Use this for initialization
	void Start () {
		placedTracks = new List<Track>();
		Build();
	}
	
	// Update is called once per frame
	void Update () {
		if(car.transform.position.z > nextBuildMark)
			Build();
	}
}
