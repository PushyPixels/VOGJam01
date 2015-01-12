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

	public float minIdleTime = 5.0f;
	public float maxIdleTime = 10.0f;

	public AudioClip[] idleClip;
	public AudioClip[] damageClip;
	public AudioSource playerDamageSource;
	public GameObject deathSound;

	private GameObject player;

	// Use this for initialization
	void Start ()
	{
		Invoke ("PlayIdleSound",Random.Range(minIdleTime,maxIdleTime));
	}

	void PlayIdleSound()
	{
		audio.PlayOneShot(idleClip[Random.Range(0,idleClip.Length)]);
		Invoke ("PlayIdleSound",Random.Range(minIdleTime,maxIdleTime));
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
				if(!playerDamageSource.isPlaying)
				{
					playerDamageSource.Play();
				}
			}
			else
			{
				playerDamageSource.Stop();
			}
		}
	}

	void Damage(float amount)
	{
		audio.PlayOneShot(damageClip[Random.Range(0,damageClip.Length)]);
		health -= amount;
		if(health <= 0.0f)
		{
			Instantiate(deathSound,transform.position,Quaternion.identity);
			BroadcastMessage("Die",SendMessageOptions.DontRequireReceiver);
		}
		//Destroy (gameObject);
	}
}
