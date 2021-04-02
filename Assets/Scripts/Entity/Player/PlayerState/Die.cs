namespace EntitySystem.Player.State
{
	public class Die : PlayerModelState
	{
		public Die(PlayerModel playerModel) : base(playerModel)
        {
        }
		
		
		protected override void OnEnter(PlayerModelState prevModelState, object arg)
		{
			
		}
	}
}