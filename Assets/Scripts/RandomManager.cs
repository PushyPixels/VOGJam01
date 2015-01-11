using UnityEngine;
using System.Collections;

public class RandomManager : MonoBehaviour
{
	public static RandomManager Instance;

	public static int seed;

	void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);

		seed = Random.Range(int.MinValue,int.MaxValue);
	}
	
	public static void EndManager()
	{
		if(Instance != null)
		{
			Destroy(Instance.gameObject);
		}
	}
}
