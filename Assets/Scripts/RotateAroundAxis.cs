using UnityEngine;
using System.Collections;

public class RotateAroundAxis : MonoBehaviour
{
	public Vector3 axis = Vector3.forward;
	public float rotationSpeed = 30.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(axis,rotationSpeed*Time.deltaTime);
	}
}
