using UnityEngine;
using System.Collections;

public class ScorePanel : MonoBehaviour
{
	public static ScorePanel Instance;

	// Use this for initialization
	void Start ()
	{
		Instance = this;
		gameObject.SetActive(false);
	}
}
