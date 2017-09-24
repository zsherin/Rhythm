using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using onemonth.utilities;

namespace onemonth.rhythm
{
	public class Stage : MonoBehaviour
	{

		public enum Directions
		{
			UP,
			RIGHT,
			LEFT,
			DOWN
		}

		Location[] StandLocations;
		public float locationCount = 72.0f;
		public GameObject locationPrefab;

		///15 meters out
		///Create a location around this circle.
		/// Go from 0->360, get r * sin(theta), r * cos(theta)
		/// Create a location at divided sections

		void CreateLocations ()
		{
			StandLocations = new Location[(int)locationCount];
			float radius = 25.0f;
			float difference = (Mathf.PI * 2) / locationCount;
			Vector3 location = transform.position;
			GameObject curObj;
			for (int i = 0; i < locationCount; i++) {
				location.x = transform.position.x + radius * Mathf.Sin (-difference * i);
				location.z = transform.position.z + radius * Mathf.Cos (-difference * i);
				curObj = Instantiate (locationPrefab, location, Quaternion.identity);
				//curObj.transform.parent = transform;
				StandLocations [i] = curObj.GetComponent<Location> ();
				StandLocations [i].index = i;
			}
		}
		// Grab all stand locations that are under this game object, store their location.
		void Awake ()
		{
			CreateLocations ();
		}

		public void GetNextLocation (BaseController controller, Directions dir)
		{
			int nextLoc = -1;
			if (dir == Directions.LEFT) {
				nextLoc = controller.myLocation.index - 1;
			}
			if (dir == Directions.RIGHT) {
				nextLoc = controller.myLocation.index + 1;
			}
			nextLoc = Utilities.RingMod (nextLoc,StandLocations.Length);
			controller.Occupy (StandLocations [nextLoc]);
		}
		//Try to occupy a location with an object, return that location that it occupies.
		public Location Occupy (int index, GameObject newObject)
		{
			//If that location is occupied, return null
			if (StandLocations [index].IsOccupied ()) {
				return null;
			}
		//If not occupied, occupy and return that location.
		else {
				StandLocations [index].Occupy (newObject);
				return StandLocations [index];
			}
		}

		public void Attack (int locationIndex)
		{
			locationIndex = Utilities.RingMod (locationIndex,StandLocations.Length);
			StandLocations [locationIndex].Flash ();
			if (StandLocations [locationIndex].IsOccupied ()) {
				GameObject.Destroy (StandLocations [locationIndex].occupant);
				StandLocations [locationIndex].Empty ();
			}

		}

		public Location IsNearbyOccupied (int locationIndex)
		{
			if (locationIndex > 0) {
				StandLocations [locationIndex - 1].Flash ();
				if (StandLocations [locationIndex - 1].IsOccupied ()) {
					return StandLocations [locationIndex - 1];
				}
			}
			if (locationIndex < StandLocations.Length - 1) {
				StandLocations [locationIndex + 1].Flash ();
				if (StandLocations [locationIndex + 1].IsOccupied ()) {
					return StandLocations [locationIndex + 1];
				}
			}
			return null;
		}

		void Update ()
		{
		
		}
	}
}