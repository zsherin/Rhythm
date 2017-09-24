using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace onemonth.rhythm{
	public class Metronome : MonoBehaviour {
		public Image metronomeStick;
		public Meter metronomeMeter;

		public int bounds = 100;
		public int speed = 2;

		private int direction = 1;
		protected float timer = 0;
		protected float top = .5f;
		protected Vector2 boundsPos;

		protected bool correctHit;
		// Use this for initialization
		void Start () {
			boundsPos = Vector2.zero;
			top = 1.0f / speed;
			correctHit = true;
		}

		protected float delta = .01f;
		public float inputWindow = .05f;
		// Update is called once per frame
		void Update () {
			if (Mathf.Abs (timer) < delta) {
				metronomeMeter.PlaySound ();
				//metronomeMeter.Flash (Color.green);
				//correctHit = false;
			}
			UpdateTimer ();
			if (Mathf.Abs(timer) > top) {
				timer =  (2 * top - Mathf.Abs(timer))*direction;
				direction = -direction;
			}
			boundsPos.x = bounds * timer * speed;
			metronomeStick.rectTransform.anchoredPosition = boundsPos;
		}

		protected virtual void  UpdateTimer()
		{
			timer += direction * Time.deltaTime;
		}
		public float GetTimer()
		{
			return timer;
		}
		/// <summary>
		/// Later this will do something useful. Now it just checks if we're within the input window
		/// </summary>
		/// <returns><c>true</c>, if input within window, <c>false</c> otherwise.</returns>
		/// <param name="code">Key that player pressed.</param>
		public float PlayerInput()
		{
			if (Mathf.Abs (timer) < inputWindow) {
				metronomeMeter.Flash (Color.green);
				return 0;
			} 
			else {
				correctHit = false;
				if (Mathf.Sign (timer) == Mathf.Sign (direction)) {
					return Mathf.Abs (timer) + top + inputWindow;
				} else {
					return Mathf.Abs (timer)+ inputWindow;
				}
			}
		}
	}
}