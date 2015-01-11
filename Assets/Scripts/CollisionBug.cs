using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionBug : MonoBehaviour
{
	public Material markedMaterial;

	public float chanceOfBug = 0.1f;
	public string brokenCollisionLayer = "BrokenCollision";
	private Material originalMaterial;

	[HideInInspector]
	public bool marked = false;
	[HideInInspector]
	public bool bugged = false;

	private static List<CollisionBug> collisionBugs = new List<CollisionBug>();

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

	void OnEnable()
	{
		collisionBugs.Add(this);
	}

	void OnDisable()
	{
		collisionBugs.Remove(this);
		Debug.Log("Disabling!");
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

	public static ScoreInfo EvaluateScore()
	{
		ScoreInfo scoreInfo = new ScoreInfo();

		foreach(CollisionBug bug in collisionBugs)
		{
			if(bug.marked && bug.bugged)
			{
				Debug.Log("Plus one point for marking a bug correctly!");
				scoreInfo.score++;
			}
			else if(bug.marked && !bug.bugged)
			{
				Debug.Log("Minus one point for marking something that's not a bug!");
				scoreInfo.penalty++;
			}

			if(bug.bugged)
			{
				scoreInfo.maxScore++;
			}
		}

		return scoreInfo;
	}
}
