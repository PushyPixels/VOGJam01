using UnityEngine;
using System.Collections;

public class SwitchGunOnButtonPress : MonoBehaviour
{
	public GameObject[] guns;
	public string switchWeaponButtonName = "Fire1";

	private int currentGun = 0;

	void Start()
	{
		foreach(GameObject gun in guns)
		{
			gun.SetActive(false);
		}

		guns[0].SetActive(true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown(switchWeaponButtonName))
		{
			guns[currentGun].SetActive(false);

			currentGun++;
			if(currentGun >= guns.Length)
			{
				currentGun = 0;
			}

			guns[currentGun].SetActive(true);
		}
	}
}
