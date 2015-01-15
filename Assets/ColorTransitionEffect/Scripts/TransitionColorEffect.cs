using UnityEngine;
using System.Collections;

public class TransitionColorEffect : MonoBehaviour
{
	public Renderer shell;
	public float transitionTime = 1.0f;

	private Color oldColor;

	// Use this for initialization
	void Start ()
	{
		oldColor = renderer.material.color;
	}

	void TransitionColor(Color newColor)
	{
		oldColor = renderer.material.color;
		renderer.material.color = newColor;
		shell.material.color = oldColor;
		shell.enabled = true;
		Invoke("DisableShell",transitionTime);
	}

	void DisableShell()
	{
		shell.enabled = false;
	}
}
