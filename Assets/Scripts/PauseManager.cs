using UnityEngine;
using System.Collections;

public class PauseManager
{
	public static void PauseGame()
	{
		Time.timeScale = float.Epsilon;
	}

	public static void UnPauseGame()
	{
		Time.timeScale = 1.0f;
	}
}
