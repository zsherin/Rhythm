using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace onemonth.rhythm
{
	public class MetronomeSlave : Metronome {

		public Metronome parent;


		protected override void UpdateTimer () {
			timer = parent.GetTimer();
		}
	}
}