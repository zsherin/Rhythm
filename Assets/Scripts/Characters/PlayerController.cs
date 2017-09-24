using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace onemonth.rhythm
{
	public class PlayerController : BaseController
	{
	
		protected override void Start ()
		{
			base.Start ();
			myLocation = currentStage.Occupy (0, gameObject);
			LookAt (Stage.Directions.RIGHT);
		}

		float delay = 0;

		//Check if we hit an input, and we are outside of our blocked time.
		protected override void Update ()
		{
			//Lower the delay that was set last time we hit a bad key
			base.Update ();
			delay -= Time.deltaTime;
			if (Input.anyKeyDown && delay <= 0) {
				//If there's no delay in our response from the metronome, process input, otherwise delay until after the grace period for the current input.
				delay = metronome.PlayerInput ();
				if (delay == 0) {
					ProcessInput ();
				}
			}
		}


		protected virtual void ProcessInput ()
		{
			if (Input.GetButtonDown ("MoveRight")) {
				currentStage.GetNextLocation (this, Stage.Directions.RIGHT);
				LookAt (Stage.Directions.RIGHT);
			} else if (Input.GetButtonDown ("MoveLeft")) {
				currentStage.GetNextLocation (this, Stage.Directions.LEFT);
				LookAt (Stage.Directions.LEFT);
			} else if (Input.GetButtonDown ("Attack")) {
				currentStage.Attack (myLocation.index + facing);
			} else if (Input.GetButtonDown ("Vertical")) {
				UpdateState (Mathf.Sign(Input.GetAxisRaw("Vertical")));
			}
		}
	}
}