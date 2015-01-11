using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBug : MonoBehaviour
{
	public GameObject marker;
	public string brokenCollisionLayer = "BrokenCollision";
	public float chanceOfBug = 0.1f;

	private int originalLayer;
	private bool bugged = false;
	private bool marked = false;

	private static List<EnemyBug> enemyBugs = new List<EnemyBug>();

	// Use this for initialization
	void Start ()
	{
		enemyBugs.Add(this);
		originalLayer = gameObject.layer;
		if(Random.value < chanceOfBug)
		{
			bugged = true;

			DoomAI doomAI = GetComponent<DoomAI>();
			doomAI.movementSpeed *= -1.0f;
			Debug.Log("I'm a bugged enemy!", gameObject);
		}
	}

	public static void ClearBugs()
	{
		enemyBugs.Clear();
	}

	void MarkBug()
	{
		if(!marked)
		{
			marker.SetActive(true);
			//gameObject.layer = LayerMask.NameToLayer(brokenCollisionLayer);
			marked = true;
		}
		else
		{
			//gameObject.layer = originalLayer;
			marker.SetActive(false);
			marked = false;
		}
	}

	public static ScoreInfo EvaluateScore()
	{
		ScoreInfo scoreInfo = new ScoreInfo();
		
		foreach(EnemyBug bug in enemyBugs)
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

	
	// Update is called once per frame
	void Update (){
	
	}
}
