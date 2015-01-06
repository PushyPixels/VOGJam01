using UnityEngine;
using System.Collections;

public class LoadLevelOnTriggerEnter : MonoBehaviour
{
	public string levelName;

	void OnTriggerEnter()
	{
		Application.LoadLevel(levelName);
	}
}
