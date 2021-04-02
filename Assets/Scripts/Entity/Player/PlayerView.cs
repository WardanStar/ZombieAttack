using Abstract.Classes;
using UnityEngine;
using UnityEngine.AI;

namespace EntitySystem.Player
{
	public class PlayerView : UnitView
	{
		public NavMeshAgent NavMeshAgent => _navMeshAgent;
		public Transform PointShot => _pointShot;

		[SerializeField] private NavMeshAgent _navMeshAgent;
		[SerializeField] private Transform _pointShot;
		
		private Player _player;

		public void Assign(Player player)
		{
			_player = player;
		}

		public void GetDamage(float damage)
		{
			_player.GetDamaged(damage);
		}
	}
}