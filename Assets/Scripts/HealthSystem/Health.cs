using UnityEngine;
using System;

public class Health : MonoBehaviour
{    
    #region Properties
	public float CurrentHealth { 
		get 
		{
			return _currentHealth;
		}
		set 
		{
			_currentHealth = value;

			if (value < 0)
			{
				_currentHealth = 0;
				Die();
			}

			if (value > _maxHealth)
				_currentHealth = _maxHealth;
		} 
	}

	public event Action OnGetDamage;
	public event Action OnGetHeal;
	public event Action OnDie;

	#endregion

	#region Fields

	[SerializeField] private float _maxHealth = 100;
	[SerializeField] private float _currentHealth;
	[SerializeField] private bool _die = false;

	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
		CurrentHealth = _maxHealth;
		//Event Listener
		OnGetDamage += () => Debug.Log("Life: " + CurrentHealth);
		OnDie += () => Debug.Log("You Die!!");

		GetDamage(20);
		GetHeal(50);
		GetDamage(10);
		GetDamage(50);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	#endregion

	#region Public Methods
	public void GetDamage(float damage)
	{
		CurrentHealth -= damage;

		//Damage Event Emiter
		OnGetDamage?.Invoke();
	}
	public void GetHeal(float life)
	{
		CurrentHealth += life;
		//Heal Event Emiter
		OnGetHeal?.Invoke();
	}

	#endregion

	#region Private Methods

	private void Die()
	{
		if (!_die)
		{
			_die = true;
			//Die Event Emiter
			OnDie?.Invoke();
		}
	}
	#endregion
}
