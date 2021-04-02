using System;
using MainSystem;
using UnityEngine;

namespace EntitySystem.Enemy
{
	public class EnemySpawner
	{
		private readonly Arm _arm;
		
		public event Action<Enemy> OnSpawnEnemy;

		private readonly Vector3 _spawnPoint;
		private readonly float _intervalSpawnZombie;
		private float _timeNextSpawn;

		public EnemySpawner(Arm arm, Vector3 spawnPoint, float intervalSpawnZombie)
		{
			_arm = arm;
			_spawnPoint = spawnPoint;
			_intervalSpawnZombie = intervalSpawnZombie;
		}
		
		public void Update()
		{
			if (Time.time < _timeNextSpawn)
				return;

			_timeNextSpawn = Time.time + _intervalSpawnZombie;
			var enemy = _arm.GetObjectManager.GetObject<Enemy>(_arm.PathToObjectSettings.PathToZombie, _spawnPoint, Quaternion.identity);
			OnSpawnEnemy?.Invoke(enemy);
		}
	}
}