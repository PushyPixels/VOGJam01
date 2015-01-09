using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public float initialHealth = 100.0f;
	public float maxHealth = 100.0f;
	private float _currentHealth;

	public float currentHealth
	{
		get
		{
			return _currentHealth;
		}
		set
		{
			_currentHealth = value;
			if(_currentHealth > maxHealth)
			{
				_currentHealth = maxHealth;
			}
		}
	}

	void Start()
	{
		_currentHealth = initialHealth;
	}
}
