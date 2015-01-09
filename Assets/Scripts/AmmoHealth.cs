using UnityEngine;
using System.Collections;

public class AmmoHealth : MonoBehaviour
{
	public int ammoAmount = 10;
	public float healthAmount = 10.0f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		CharacterController characterController = col.GetComponent<CharacterController>();

		float angle = Quaternion.Angle(Quaternion.LookRotation(characterController.velocity),transform.rotation);
		if(angle < 45.0f || angle > 135.0f)
		{
			Debug.Log("Picked up health");
		}
		else
		{
			Debug.Log("Picked up ammo");
		}

		//Destroy(
	}
}
