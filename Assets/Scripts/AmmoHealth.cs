using UnityEngine;
using System.Collections;

public class AmmoHealth : MonoBehaviour
{
	public GameObject healthEffect;
	public GameObject ammoEffect;

	public int ammoAmount = 50;
	public float healthAmount = 50.0f;

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

			GameObject player = GameObject.FindGameObjectWithTag("Player");
			PlayerHealth playerHealth = player.GetComponentInParent<PlayerHealth>();
			
			playerHealth.currentHealth += healthAmount;

			Instantiate(healthEffect,transform.position,Quaternion.identity);
		}
		else
		{
			Debug.Log("Picked up ammo");
			GameObject currentGun = GameObject.FindGameObjectWithTag("CurrentGun");
			Gun gun = currentGun.GetComponent<Gun>();

			gun.currentAmmo += ammoAmount;

			Instantiate(ammoEffect,transform.position,Quaternion.identity);
		}

		Destroy(gameObject);
	}
}
