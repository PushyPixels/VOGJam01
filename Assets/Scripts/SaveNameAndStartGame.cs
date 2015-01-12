using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveNameAndStartGame : MonoBehaviour
{
	public InputField textField;

	// Use this for initialization
	void Start ()
	{
		textField.text = PlayerPrefs.GetString("Name");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			PlayerPrefs.SetString("Name", textField.text);
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
