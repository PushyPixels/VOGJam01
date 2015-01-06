using UnityEngine;
using System.Collections;

public class GibOnDeath : MonoBehaviour
{
	public GameObject gib;
	public GameObject objectToDestroy;

	void Start()
	{
		if(objectToDestroy == null)
		{
			objectToDestroy = gameObject;
		}
	}

	void Die()
	{
		Instantiate(gib,transform.position,transform.rotation);
		Destroy(objectToDestroy);
	}
}
