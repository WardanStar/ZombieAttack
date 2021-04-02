using System;
using Abstract;
using UnityEngine;

namespace EntitySystem.Player
{
	public class Player : ILive
	{
		public event Action OnDie;
		
		public float Health { get; private set; }

		public Player(float health)
		{
			Health = health;
		}

		public void GetDamaged(float damage)
		{
			Mathf.Min(Health -= damage, 0f);
			if (!Mathf.Approximately(Health, 0f))
				return;
			
			OnDie?.Invoke();
		}
	}
}