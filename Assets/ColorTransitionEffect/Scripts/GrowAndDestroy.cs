using UnityEngine;
using System.Collections;

public class GrowAndDestroy : MonoBehaviour
{
	public float growRate = 5.0f;
	public float destroyDelay = 1.0f;

	// Use this for initialization
	void Start ()
	{
		Destroy(gameObject,destroyDelay);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.localScale += Vector3.one*growRate*Time.deltaTime;
	}
}
