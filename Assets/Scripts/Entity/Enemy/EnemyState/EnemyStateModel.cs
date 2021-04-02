using Game.Common.StateMachines;

namespace EntitySystem.Enemy.EnemyState
{
	public class EnemyStateModel : State<EnemyStateModel>
	{
		protected readonly EnemyModel EnemyModel;

		public EnemyStateModel(EnemyModel enemyModel)
		{
			EnemyModel = enemyModel;
		}
		
		public virtual void Update(){}
	}
}