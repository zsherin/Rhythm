using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace onemonth.utilities{
	public class Utilities : MonoBehaviour {

		/// <summary>
		/// Mod function that goes from [0,m)
		/// </summary>
		/// <returns>The number n modulo m.</returns>
		/// <param name="n">number to be modded.</param>
		/// <param name="m">modulus.</param>
		public static int RingMod(int n, int m)
		{
			return (n % m + m) % m;
		}
	}
}
