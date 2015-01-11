using UnityEngine;
using System.Collections;

public class LoadNextLevelOnAnyKey : MonoBehaviour
{
	private bool lastKeyState = false;

	void Update()
	{
		if(Input.anyKeyDown)
		{
			lastKeyState = true;
		}
		else if(Input.anyKey)
		{
		}
		else if(lastKeyState == true)
		{
			lastKeyState = false;
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
