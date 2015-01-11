using UnityEngine;
using System.Collections;

public class LoadLevelOnAnyKey : MonoBehaviour
{
	public string levelName;
	
	void Update()
	{
		if(Input.anyKeyDown)
		{
			Application.LoadLevel(levelName);
		}
	}
}
