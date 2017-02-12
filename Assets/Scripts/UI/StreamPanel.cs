using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamPanel : MonoBehaviour {

	public void BuyStream()
	{
		GameState.StartNewStream ("Best stream" + Random.Range (0, 10000));
	}
}
