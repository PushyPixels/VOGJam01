using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayScorePenalty : MonoBehaviour
{
	private Text text;
	private string initialText;
	
	void Start()
	{
		text = GetComponent<Text>();
		initialText = text.text;
	}
	
	// Update is called once per frame
	void Update ()
	{	
		ScoreInfo scoreInfo = CollisionBug.EvaluateScore();
		text.text = initialText + scoreInfo.penalty;
	}
}
