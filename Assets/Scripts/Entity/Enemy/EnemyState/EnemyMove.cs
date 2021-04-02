using EntitySystem.Enemy;
using EntitySystem.Enemy.EnemyState;
using UnityEngine;

namespace DefaultNamespace.Enemy.EnemyState
{
	public class EnemyMove : EnemyStateModel
	{
		public EnemyMove(EnemyModel enemyModel) : base(enemyModel)
		{
		}

		public override void Update()
		{
			if (Vector3.Distance(
				EnemyModel.Enemy.transform.position, EnemyModel.PlayerView.transform.position) < EnemyModel.Enemy.DistanceAttack)
			{
				StateMachine.SetState<EnemyAttack>();
			}

			EnemyModel.Enemy.NavMeshAgent.SetDestination(EnemyModel.PlayerView.transform.position);
		}
	}
}