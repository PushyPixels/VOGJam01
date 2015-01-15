using UnityEngine;
using System.Collections;

public class ExampleEffect : MonoBehaviour
{
	public GameObject transitionSphere;

	private int colorOffset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ViewportPointToRay(new Vector2(0.5f,0.5f)),out hit))
			{
				hit.collider.SendMessage("TransitionColor",new Color(Random.value,Random.value,Random.value));
				Instantiate(transitionSphere,hit.point,Quaternion.identity);
			}
		}
	}
}
