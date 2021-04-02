using DefaultNamespace.Enemy.EnemyState;
using EntitySystem.Enemy.EnemyState;
using EntitySystem.Player;
using Game.Common.StateMachines;

namespace EntitySystem.Enemy
{
	public class EnemyModel
	{
		public readonly Enemy Enemy;
		public readonly PlayerView PlayerView;
		
		public readonly StateMachine<EnemyStateModel> StateMachine; 

		public EnemyModel(Enemy enemy, PlayerView playerView)
		{
			Enemy = enemy;
			PlayerView = playerView;
			
			StateMachine = new StateMachine<EnemyStateModel>();
			
			StateMachine.SetStates(new EnemyStateModel[]
			{
				new EnemyMove(this),
				new EnemyAttack(this)
			});
			
			StateMachine.SetState<EnemyMove>();
		}
	}
}