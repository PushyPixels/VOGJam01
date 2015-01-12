using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerName : MonoBehaviour
{
	public Text target;

	// Use this for initialization
	void Start ()
	{
		target.text = target.text.Replace("<>",PlayerPrefs.GetString("Name"));
	}
}
