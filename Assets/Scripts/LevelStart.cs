using UnityEngine;
using System.Collections;

public class LevelStart : MonoBehaviour
{
	public static LevelStart Instance;

	void Awake()
	{
		Instance = this;
		Random.seed = RandomManager.seed;
		AmmoHealthBug.ClearBugs();
	}
}
