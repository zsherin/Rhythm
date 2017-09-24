using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace onemonth.rhythm{
	public class Meter : MonoBehaviour {
		Image myImage;
		Color originalColor;
		AudioSource source;
		// Use this for initialization
		void Start () {
			myImage = GetComponent<Image> ();
			source = GetComponent<AudioSource> ();
			originalColor = myImage.color;
		}
		
		// Update is called once per frame
		void Update () {
			if (timer < 0) {
				myImage.color = originalColor;
			} else {
				timer -= Time.deltaTime;
			}
		}

		private float timer = 0;
		public void PlaySound()
		{
			if (source != null) {
				source.Play ();
			}
		}
		public void Flash(Color newColor)
		{
			timer = .2f;
			myImage.color = newColor;
			//source.Play ();
		}
	}
}