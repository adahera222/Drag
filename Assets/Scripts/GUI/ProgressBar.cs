using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {
	void Start()
	{
		SetProgress(0f);
	}
	public void SetProgress(float progress)
	{
		transform.localScale = new Vector3(progress,0.1f,0.1f);
	}
}
