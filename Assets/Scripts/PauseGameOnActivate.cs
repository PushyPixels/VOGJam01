using UnityEngine;
using System.Collections;

public class PauseGameOnActivate : MonoBehaviour
{
	void OnEnable()
	{
		PauseManager.PauseGame();
	}

	void OnDisable()
	{
		PauseManager.UnPauseGame();
	}
}
