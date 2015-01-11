using UnityEngine;
using System.Collections;

public class FaceAI : MonoBehaviour
{
	public float movementSpeed = 1.0f;
	public float closestDistance = 1.0f;
	public float health = 1.0f;

	public GameObject projectile;
	public Transform attackPosition;
	public Sprite attackFrame;
	public float attackFrameTime = 0.5f;
	public float minAttackDelay = 1.0f;
	public float maxAttackDelay = 2.0f;

	private Sprite defaultFrame;
	private SpriteRenderer spriteRenderer;

	private GameObject player;
	
	// Use this for initialization
	void Start ()
	{
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		defaultFrame = spriteRenderer.sprite;

		Invoke ("Attack",Random.Range(minAttackDelay,maxAttackDelay));
	}

	void Attack()
	{
		Instantiate (projectile,attackPosition.position,attackPosition.rotation);
		spriteRenderer.sprite = attackFrame;
		Invoke("ResetSpriteFrame", attackFrameTime);

		Invoke("Attack",Random.Range(minAttackDelay,maxAttackDelay));
	}

	void ResetSpriteFrame()
	{
		spriteRenderer.sprite = defaultFrame;
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
