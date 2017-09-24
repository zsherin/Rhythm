using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace onemonth.rhythm{
public class Location : MonoBehaviour {

	public GameObject occupant;
	public int index;
	// Use this for initialization
	void Start () {
		//index = transform.GetSiblingIndex ();
	}

	public bool IsOccupied()
	{
		return occupant != null;
	}

	public void Occupy(GameObject go)
	{
		occupant = go;
		go.transform.position = new Vector3 (transform.position.x, go.transform.position.y, transform.position.z);
	}

	public void Empty()
	{
		occupant = null;
	}
	float flashTime;
	public void Flash()
	{
		GetComponent<MeshRenderer> ().material.color = Color.green;
		flashTime = 1.0f;
	}
	// Update is called once per frame
	void Update () {
		if (flashTime <= 0 && flashTime > -100) {
			flashTime = -100;

			GetComponent<MeshRenderer> ().material.color = Color.blue;
		}
		flashTime -= Time.deltaTime;
	}
}
}