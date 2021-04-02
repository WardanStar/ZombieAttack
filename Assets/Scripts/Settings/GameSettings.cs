using UnityEngine;

namespace SettingsSystem
{
	[CreateAssetMenu()]
	public class GameSettings : ScriptableObject
	{
		public float Health => _health;
		public float Speed => _speed;
		public float DistanceAttack => _distanceAttack;
		public float IntervalSpawnEnemy => _intervalSpawnEnemy;

		[Header("Player")]
		[SerializeField] private float _health;
		[SerializeField] private float _speed;
		[SerializeField] private float _distanceAttack;
		[Header("Enemy")] 
		[SerializeField] private float _intervalSpawnEnemy;
	}
}