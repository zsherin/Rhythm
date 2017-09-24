using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace onemonth.rhythm{
public class EnemyController : BaseController {

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		myLocation = currentStage.Occupy (5,gameObject);
		LookAt (Stage.Directions.LEFT);
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
	}
}
}
