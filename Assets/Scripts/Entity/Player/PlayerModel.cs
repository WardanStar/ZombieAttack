using EntitySystem.Player.State;
using EntitySystem.Weapons;
using Game.Common.StateMachines;
using UnityEngine;

namespace EntitySystem.Player
{
	public class PlayerModel
	{
		public readonly PlayerView PlayerView;
		public readonly StateMachine<PlayerModelState> StateMachine;

		public PlayerModel(PlayerView playerView, UnitWeaponModel unitWeaponModel, Transform pointShot, float speedPlayer, float distanceAttack)
		{
			StateMachine = new StateMachine<PlayerModelState>();
			PlayerView = playerView;
			StateMachine.SetStates(new PlayerModelState[]
            {
            	new OrdersWaitingAndCheckingArea(this, distanceAttack), 
            	new PlayerMove(this, speedPlayer),
            	new AttackingState(this, unitWeaponModel, pointShot), 
            	new Die(this)
            });
                
            StateMachine.SetState<OrdersWaitingAndCheckingArea>();
		}
	}
}