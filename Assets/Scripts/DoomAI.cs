using UnityEngine;
using System.Collections;

public class DoomAI : MonoBehaviour
{
	public float movementSpeed = 1.0f;
	public float closestDistance = 1.0f;

	private GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}
		else
		{
			Vector3 vectorToPlayer = player.transform.position - transform.position;

			transform.rotation = Quaternion.LookRotation(vectorToPlayer);

			if(vectorToPlayer.magnitude > closestDistance)
			{
				transform.position += transform.forward*movementSpeed*Time.deltaTime;
			}
		}
	}
}
