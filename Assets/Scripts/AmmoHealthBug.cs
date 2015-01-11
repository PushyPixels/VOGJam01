using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AmmoHealthBug : MonoBehaviour
{
	public GameObject marker;
	public string brokenCollisionLayer = "BrokenCollision";
	public float chanceOfBug = 0.1f;

	private int originalLayer;
	private bool bugged = false;
	private bool marked = false;

	private static List<AmmoHealthBug> ammoHealthBugs = new List<AmmoHealthBug>();

	// Use this for initialization
	void Start ()
	{
		ammoHealthBugs.Add(this);
		originalLayer = gameObject.layer;
		if(Random.value < chanceOfBug)
		{
			bugged = true;

			AmmoHealth ammoHealth = GetComponent<AmmoHealth>();
			ammoHealth.ammoPercentage *= -1.0f;
			ammoHealth.healthAmount *= -1.0f;

			Debug.Log("I'm an evil powerup!", gameObject);
		}
	}

	public static void ClearBugs()
	{
		ammoHealthBugs.Clear();
	}

	void MarkBug()
	{
		if(!marked)
		{
			marker.SetActive(true);
			gameObject.layer = LayerMask.NameToLayer(brokenCollisionLayer);
			marked = true;
		}
		else
		{
			gameObject.layer = originalLayer;
			marker.SetActive(false);
			marked = false;
		}
	}

	public static ScoreInfo EvaluateScore()
	{
		ScoreInfo scoreInfo = new ScoreInfo();
		
		foreach(AmmoHealthBug bug in ammoHealthBugs)
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
