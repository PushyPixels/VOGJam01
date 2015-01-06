using UnityEngine;
using System.Collections;

public class BasicGun : MonoBehaviour
{
	public string fireButton = "Fire1";
	public float fireDelay = 0.1f;
	public float damage = 1.0f;
	public int initialAmmo = 10;
	public int maxAmmo = 100;

	private int currentAmmo;
	private bool canFire = true;

	// Use this for initialization
	void Start ()
	{
		currentAmmo = initialAmmo;
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetButtonDown(fireButton) && currentAmmo > 0 && canFire)
		{
			//Fire logic
			RaycastHit hit;
			if(Physics.Raycast(transform.position,transform.forward,out hit))
			{
				hit.collider.SendMessage("Damage",damage,SendMessageOptions.DontRequireReceiver);;
			}

			currentAmmo--;
			canFire = false;
			Invoke("CanFireNow", fireDelay);
		}
	}

	void CanFireNow()
	{
		canFire = true;
	}
}
