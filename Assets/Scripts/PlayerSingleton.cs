using UnityEngine;
using System.Collections;

public class PlayerSingleton : MonoBehaviour
{
	public static PlayerSingleton Instance;

	// Use this for initialization
	void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Instance.transform.position = transform.position;
			Instance.transform.rotation = transform.rotation;
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
	}
}
