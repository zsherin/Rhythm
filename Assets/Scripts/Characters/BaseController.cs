using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using onemonth.utilities;
namespace onemonth.rhythm{
	public class BaseController : MonoBehaviour {
		public enum Stance
		{
			UP,
			MID,
			DOWN
		}

		public Metronome metronome;
		public Stage currentStage;
		public Location myLocation;
		public Transform myWeapon;

		public Stance myStance = Stance.MID;
		private LookAtTarget targetFacer;
		public int facing = 1;
		// Use this for initialization
		protected virtual void Start () {
			targetFacer = GetComponent<LookAtTarget> ();
		}
		/// <summary>
		/// Look in a direction
		/// </summary>
		/// <param name="dir">Look Direction.</param>
		protected virtual void LookAt(Stage.Directions dir)
		{
			if (dir == Stage.Directions.LEFT) {
				facing = -1;
			} else {
				facing = 1;
			}
			targetFacer.LookAt ();
			UpdateWeaponLocation ();
			//transform.LookAt (transform.position + Vector3.right * facing);
		}

		/// <summary>
		/// Move our weapon in sync with state
		/// </summary>
		protected virtual void UpdateWeaponLocation ()
		{
			Vector3 tmpPosition = myWeapon.localPosition;
			switch (myStance) {
			case Stance.DOWN:
				tmpPosition.y = -.2f;
				break;
			case Stance.MID:
				tmpPosition.y = 0;
				break;
			case Stance.UP:
				tmpPosition.y = .2f;
				break;
			}
			if (facing >= 0) {
				tmpPosition.x = Mathf.Abs (tmpPosition.x);
			} else {
				tmpPosition.x = -1*Mathf.Abs (tmpPosition.x);
			}
			myWeapon.localPosition = tmpPosition;
		}

		/// <summary>
		/// Updates the state.
		/// </summary>
		protected virtual void UpdateState(float inputVal)
		{
			Debug.Log (Mathf.Clamp ((int)(myStance) - inputVal, 0, 2));
			myStance = (Stance)(Mathf.Clamp ((int)(myStance) - inputVal, 0, 2));
		}
		/// <summary>
		/// Occupy the specified Location.
		/// </summary>
		/// <param name="newLoc">New location.</param>
		public void Occupy(Location newLoc)
		{
			myLocation.Empty ();
			newLoc.Occupy (gameObject);
			myLocation = newLoc;
		}

		protected virtual void Update () {
			
		}
			

	}
}