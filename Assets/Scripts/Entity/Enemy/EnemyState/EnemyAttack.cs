namespace EntitySystem.Enemy.EnemyState
{
	public class EnemyAttack : EnemyStateModel
	{
		public EnemyAttack(EnemyModel enemyModel) : base(enemyModel)
		{
		}

		protected override void OnEnter(EnemyStateModel prevState, object arg)
		{
		}
	}
}