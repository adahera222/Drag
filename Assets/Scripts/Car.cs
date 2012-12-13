using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
	public bool accelerating;
	public bool breaks;
	public int currentGear = -1;
	public int topGear = 4;
	public float[] accelerations;
	public float[] decelerations;
	public float[] maxSpeeds;
	public float breaksDeceleration = 0.5f;
	public float speed = 0;
	public int hittimes = 0;
	public ProgressBar speedometor;
	public WheelCollider[] wheels;
	void OnEnable()
	{
		Inputron.StartAccelerate += OnStartAccelerate;
		Inputron.StopAccelerate += OnStopAccelerate;

		Inputron.StartBreaks += OnStartBreaks;
		Inputron.StopBreaks += OnStopBreaks;
		
		Inputron.SteerLeft += OnSteerLeft;
		Inputron.SteerRight += OnSteerRight;

		Inputron.GearUp += OnGearUp;
		Inputron.GearDown += OnGearDown;
	}

	void OnStartAccelerate()
	{
		accelerating = true;
	}

	void OnStopAccelerate()
	{
		accelerating = false;
	}

	void OnStartBreaks()
	{
		breaks = true;
	}

	void OnStopBreaks()
	{
		breaks = false;
	}

	void OnSteerLeft()
	{
		iTween.MoveAdd(gameObject,Vector3.left * 3,0.25f);
	}

	void OnSteerRight()
	{
		iTween.MoveAdd(gameObject,Vector3.right * 3,0.25f);
	}

	void OnGearUp()
	{
		if(currentGear < topGear)
		{
			currentGear++;
		}
	}

	void OnGearDown()
	{
		if(currentGear > 0)
		{
			currentGear--;
		}	
	}

	public void Hit()
	{
		speed *= 0.5f;
		hittimes++;
	}
	
	void OnDisable()
	{
		Inputron.StartAccelerate -= OnStartAccelerate;
		Inputron.StopAccelerate -= OnStopAccelerate;

		Inputron.StartBreaks -= OnStartBreaks;
		Inputron.StopBreaks -= OnStopBreaks;
		
		Inputron.SteerLeft -= OnSteerLeft;
		Inputron.SteerRight -= OnSteerRight;

		Inputron.GearUp -= OnGearUp;
		Inputron.GearDown -= OnGearDown;
	}

	void OnGUI()
	{
		GUI.Label (new Rect (0,0,100,50), "CurrentGear: " + (currentGear+1));
		GUI.Label (new Rect (0,20,100,50), "Speed: " + (int) (speed * 3.6f) + " km/h");
		GUI.Label (new Rect (0,40,100,50), "right alt - GearUp");
		GUI.Label(new Rect(0,60,100,50), "left alt - GearDown");
		GUI.Label(new Rect(0,80,100,50), "Hitted: " + hittimes);
		if(hittimes > 5)
		{
			speed = 0;
			currentGear = -10;
			if (GUI.Button (new Rect (Screen.width / 2 - 350 / 2,Screen.height / 2 - 350 / 2,350,350), "YOU'RE HIGHSCORE IS: " + (int)transform.position.z + " TRY AGAIN")) {
				Application.LoadLevel(0);			
			}
		}
	}

	void FixedUpdate () {
		if(currentGear >= 0){
			if(accelerating){
				if(speed < maxSpeeds[currentGear]){
					speed += accelerations[currentGear] * Time.deltaTime;
				}
			}
			if(speed > 0){
				speed -= decelerations[currentGear] * Time.deltaTime;
			}
			if(breaks){
				if(speed > 0){
					speed -= breaksDeceleration * Time.deltaTime;
				}
			}
			speedometor.SetProgress(speed / maxSpeeds[currentGear]);
		}
		foreach (var o in wheels) {
			o.motorTorque = speed;
		}
		//transform.position = Vector3.Lerp(transform.position, transform.position+Vector3.forward*speed, Time.deltaTime);
	}	
}
