using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayHealth : MonoBehaviour
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
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		PlayerHealth playerHealth = player.GetComponentInParent<PlayerHealth>();

		text.text = playerHealth.currentHealth.ToString() + initialText;
	}
}
