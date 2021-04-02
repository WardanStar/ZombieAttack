using EntitySystem.Weapons;
using MainSystem;
using UnityEngine;

namespace EntitySystem.Player
{
	public class PlayerController
	{
		private readonly Player _player;
		private readonly UnitWeaponModel _unitWeaponModel;
		private readonly PlayerModel _playerModel;
		
		public PlayerController(
			Arm arm,
			Player player,
			PlayerView playerView,
			ResourcesWeapons resourcesWeapons,
			float distanceAttack,
			float speedPlayer)
		{
			_player = player;
			
			_unitWeaponModel = new UnitWeaponModel(resourcesWeapons, arm, playerView.PointShot);
			_playerModel = new PlayerModel(playerView, _unitWeaponModel, playerView.PointShot, speedPlayer, distanceAttack);
		}

		public void Tick()
		{
			_playerModel.StateMachine.CurrentState.Update();
			_unitWeaponModel.StateMachine.CurrentState.Update();
		}
		
		public void Move(Vector3 pointMove)
		{
			_playerModel.StateMachine.CurrentState.Move(pointMove);
		}

		public void Attack()
		{
			_unitWeaponModel.StateMachine.CurrentState.Attack();
		}
	}
}