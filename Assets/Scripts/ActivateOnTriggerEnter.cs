using UnityEngine;
using System.Collections;

public class ActivateOnTriggerEnter : MonoBehaviour
{
	public GameObject objectToActivate;
	public string gameObjectTagToActivate;

	void OnTriggerEnter()
	{
		if(objectToActivate != null)
		{
			objectToActivate.SetActive(true);
		}

		foreach(GameObject obj in GameObject.FindGameObjectsWithTag(gameObjectTagToActivate))
		{
			obj.SetActive(true);
		}
	}
}
