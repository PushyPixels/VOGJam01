using UnityEngine;
using System.Collections;

public class DoomAI : MonoBehaviour
{
	public float movementSpeed = 1.0f;
	public float closestDistance = 1.0f;
	public float damageDistance = 0.5f;
	public float damagePerSecond = 1.0f;
	public float health = 1.0f;
	public bool lookAtPlayer = true;

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

			if(lookAtPlayer)
			{
				transform.rotation = Quaternion.LookRotation(vectorToPlayer);
			}

			float distance = vectorToPlayer.magnitude;

			if(distance > closestDistance)
			{
				transform.position += transform.forward*movementSpeed*Time.deltaTime;
			}

			if(distance < damageDistance)
			{
				PlayerHealth.currentHealth -= damagePerSecond*Time.deltaTime;
			}
		}
	}

	void Damage(float amount)
	{
		health -= amount;
		if(health <= 0.0f)
		{
			BroadcastMessage("Die",SendMessageOptions.DontRequireReceiver);
		}
		//Destroy (gameObject);
	}
}
