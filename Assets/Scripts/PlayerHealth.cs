using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public static PlayerHealth Instance;

	public float initialHealth = 100.0f;
	public float maxHealth = 100.0f;
	private float _currentHealth;

	void Start()
	{
		Instance = this;
		_currentHealth = initialHealth;
	}

	public static float currentHealth
	{
		get
		{
			return Instance._currentHealth;
		}
		set
		{
			Instance._currentHealth = value;
			if(Instance._currentHealth > Instance.maxHealth)
			{
				Instance._currentHealth = Instance.maxHealth;
			}
			else if(Instance._currentHealth <= 0.0f)
			{
				Instance._currentHealth = 0.0f;
				PlayerSingleton.EndManager();
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
