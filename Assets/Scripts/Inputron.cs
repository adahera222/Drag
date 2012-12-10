using UnityEngine;
using System.Collections;
using System;

public class Inputron : MonoBehaviour {
	public static event Action StartAccelerate;
	public static event Action StopAccelerate;

	public static event Action StartBreaks;
	public static event Action StopBreaks;

	public static event Action SteerLeft;
	public static event Action SteerRight;

	public static event Action GearUp;
	public static event Action GearDown;

	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Debug.Log("Left");
			if(SteerLeft != null)
				SteerLeft();
		}
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			Debug.Log("StartAccelerate");			
			if(StartAccelerate != null)
				StartAccelerate();
		}
		if(Input.GetKeyUp(KeyCode.UpArrow))
		{
			Debug.Log("StopAccelerate");
			if(StopAccelerate != null)
				StopAccelerate();
		}
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			Debug.Log("StartBreaks");
			if(StartBreaks != null)
				StartBreaks();
		}

		if(Input.GetKeyUp(KeyCode.DownArrow))
		{
			Debug.Log("StopBreaks");
			if(StopBreaks != null)
				StopBreaks();
		}
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			Debug.Log("Right");
			if(SteerRight != null)
				SteerRight();
		}
		if(Input.GetKeyDown(KeyCode.RightAlt))
		{
			Debug.Log("GearUp");
			if(GearUp != null)
				GearUp();
		}
		if(Input.GetKeyDown(KeyCode.LeftAlt))
		{
			Debug.Log("GearDown");
			if(GearDown != null)
				GearDown();
		}
	}
}
