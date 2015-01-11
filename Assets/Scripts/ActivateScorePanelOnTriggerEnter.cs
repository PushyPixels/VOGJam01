using UnityEngine;
using System.Collections;

public class ActivateScorePanelOnTriggerEnter : MonoBehaviour {

	void OnTriggerEnter()
	{
		ScorePanel.Instance.gameObject.SetActive(true);
	}
}
