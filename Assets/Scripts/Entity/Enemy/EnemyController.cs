using System.Collections.Generic;
using EntitySystem.Player;
using MainSystem;
using UnityEngine;

namespace EntitySystem.Enemy
{
	public class EnemyController
	{
		private readonly EnemySpawner _enemySpawner;

		private readonly Arm _arm;
		private readonly PlayerView _playerView;
		private readonly List<EnemyModel> _enemyModels = new List<EnemyModel>();

		public EnemyController(Arm arm, PlayerView playerView, Vector3 spawnPoint,  float intervalSpawn)
		{
			_enemySpawner = new EnemySpawner(arm, spawnPoint, intervalSpawn);
			_arm = arm;
			_playerView = playerView;
			_enemySpawner.OnSpawnEnemy += OnEnemySpawnerSpawnEnemy;
		}

		public void Tick()
		{
			_enemySpawner.Update();
			
			foreach (var enemyModel in _enemyModels)
			{
				if (!enemyModel.Enemy.gameObject.activeSelf ||
				    enemyModel.StateMachine.CurrentState == null)
					continue;
				
				enemyModel.StateMachine.CurrentState.Update();
			}
		}
		
		private void OnEnemySpawnerSpawnEnemy(Enemy enemy)
        {
        	_enemyModels.Add(new EnemyModel(enemy, _playerView));
            enemy.OnDieEnemy += OnEnemyDieEnemy;
        }

		private void OnEnemyDieEnemy(Enemy enemy, Transform enemyDieTransform, float powerImpact)
		{
			enemy.OnDieEnemy -= OnEnemyDieEnemy;
			var ragdoll = _arm.GetObjectManager.GetObject<Transform>(_arm.PathToObjectSettings.PathToZombieRagdoll, enemyDieTransform.position,
				enemyDieTransform.rotation, 5f);

			ragdoll.gameObject.GetComponentInChildren<Rigidbody>().velocity = new Vector3(powerImpact, powerImpact, powerImpact);
		}
	}
}