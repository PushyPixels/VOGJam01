using UnityEngine;
using System.Collections;

public class CollisionBug : MonoBehaviour
{
	public Material markedMaterial;

	public float chanceOfBug = 0.1f;
	public string brokenCollisionLayer = "BrokenCollision";
	private Material originalMaterial;
	private bool marked = false;
	private bool bugged = false;

	// Use this for initialization
	void Start ()
	{
		originalMaterial = renderer.sharedMaterial;
		if(Random.value < chanceOfBug)
		{
			bugged = true;
			gameObject.layer = LayerMask.NameToLayer(brokenCollisionLayer);
			Debug.Log("I'm not colliding right!", gameObject);
		}
	}

	void MarkBug()
	{
		if(!marked)
		{
			renderer.sharedMaterial = markedMaterial;
			marked = true;
		}
		else
		{
			renderer.sharedMaterial = originalMaterial;
			marked = false;
		}
	}

	void OnDestroy()
	{
		if(marked && bugged)
		{
			Debug.Log("Plus one point for marking a bug correctly!");
		}
		else if(marked && !bugged)
		{
			Debug.Log("Minus one point for marking something that's not a bug!");
		}
		else if(!marked && bugged)
		{
			Debug.Log("Minus one point for missing a bug!");
		}
	}
}
