using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayAmmo : MonoBehaviour
{	
	private Text text;
	private string initialText;

	void Start()
	{
		text = GetComponent<Text>();
		initialText = text.text;
	}

	// Update is called once per frame
	void Update ()
	{
		GameObject currentGun = GameObject.FindGameObjectWithTag("CurrentGun");
		Gun gun = currentGun.GetComponent<Gun>();

		if(gun.maxAmmo > 0)
		{
			text.text = initialText + gun.currentAmmo.ToString() + "/" + gun.maxAmmo.ToString();
		}
		else
		{
			text.text = initialText + "<b>∞</b>"; // + infinitySymbolSizeOverride + ">∞</size>";
		}
	}
}
