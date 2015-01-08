using UnityEngine;
using System.Collections;

public class BugMarker : MonoBehaviour
{
	public string buttonName = "Fire1";

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown(buttonName))
		{
			//Fire logic
			RaycastHit hit;
			if(Physics.Raycast(transform.position,transform.forward,out hit))
			{
				hit.collider.SendMessage("MarkBug",SendMessageOptions.DontRequireReceiver);;
			}
		}
	}
}
