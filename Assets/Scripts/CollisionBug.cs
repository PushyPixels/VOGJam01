using UnityEngine;
using System.Collections;

public class CollisionBug : MonoBehaviour
{
	public float chanceOfBug = 0.1f;
	public string brokenCollisionLayer = "BrokenCollision";

	// Use this for initialization
	void Start ()
	{
		if(Random.value < chanceOfBug)
		{
			gameObject.layer = LayerMask.NameToLayer(brokenCollisionLayer);
			Debug.Log("I'm not colliding right!", gameObject);
		}
	}

	void MarkBug()
	{

	}
}
