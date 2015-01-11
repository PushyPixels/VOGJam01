using UnityEngine;
using System.Collections;

public class ActivateOnTriggerEnter : MonoBehaviour
{
	public GameObject objectToActivate;

	void OnTriggerEnter()
	{
		objectToActivate.SetActive(true);
	}
}
