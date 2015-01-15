using UnityEngine;
using System.Collections;

public class Mouselock : MonoBehaviour {

	// Update is called once per frame
	void Update ()
	{
		Screen.showCursor = false;
		Screen.lockCursor = true;
	}
}
