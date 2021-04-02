using System;
using Abstract.Classes;
using EntitySystem.Player;
using UnityEngine;
using UnityEngine.AI;

namespace EntitySystem.Enemy
{
	public class Enemy : UnitView
	{
		public float DistanceAttack => _distanceAttack;
		public float Speed => _speed;
		public float Damage => _damage;
		public NavMeshAgent NavMeshAgent => _navMeshAgent;

		public event Action<Enemy, Transform, float> OnDieEnemy;

		[SerializeField] private NavMeshAgent _navMeshAgent;
		[SerializeField] private float _health;
		[SerializeField] private float _distanceAttack;
		[SerializeField] private float _speed;
		[SerializeField] private float _damage;
		
		public float Health { get; private set; }

		public void GetDamaged(float damage, float powerImpact)
		{
			Mathf.Min(Health -= damage, 0);
			if (!Mathf.Approximately(Health, 0f))
				return;
			
			OnDieEnemy?.Invoke(this, gameObject.transform, powerImpact);
			gameObject.SetActive(false);
		}

		public void Attack()
		{
			var trans = transform;
			
			if (Physics.Raycast(trans.position, trans.forward, out RaycastHit hit, 1f))
			{
				if (hit.collider.tag == "Player")
				{
					hit.collider.gameObject.GetComponent<PlayerView>().GetDamage(_damage);
				}
			}
		}

		private void OnEnable()
		{
			Health = _health;
			_navMeshAgent.speed = _speed;
		}
	}
}