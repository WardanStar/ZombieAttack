using Game.Common.StateMachines;
using UnityEngine;

namespace EntitySystem.Player.State
{
	public abstract class PlayerModelState : State<PlayerModelState>
	{
		protected PlayerModel PlayerModel;
		
		protected PlayerModelState(PlayerModel playerModel)
		{
			PlayerModel = playerModel;
		}
		
		public virtual void Move(Vector3 pointMove){}
		public virtual void Update(){}
	}
}