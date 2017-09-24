using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace onemonth.utilities{
	public class LookAtTarget : MonoBehaviour {
		public Transform target;
		public bool forward = true;
		// Use this for initialization
		void Start () {
			
		}
		public void LookAt(bool facing)
		{
			forward = facing;
			LookAt ();
		}
		public void LookAt()
		{
			if (forward) {
				transform.LookAt (target);
			} else {
				transform.LookAt (transform.position - target.position);
			}
		}
		// Update is called once per frame
		void Update () {
			LookAt (forward);
		}
	}
}