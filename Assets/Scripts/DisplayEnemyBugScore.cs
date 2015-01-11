using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayEnemyBugScore : MonoBehaviour
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
		ScoreInfo scoreInfo = EnemyBug.EvaluateScore();
		text.text = initialText + scoreInfo.score + "/" + scoreInfo.maxScore;
	}
}
