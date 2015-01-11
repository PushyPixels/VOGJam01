using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayPowerupBugScore : MonoBehaviour
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
		ScoreInfo scoreInfo = AmmoHealthBug.EvaluateScore();
		text.text = initialText + scoreInfo.score + "/" + scoreInfo.maxScore;
	}
}
