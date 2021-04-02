using EntitySystem.Weapons;
using EntitySystem.Weapons.State;
using UnityEngine;

namespace EntitySystem.Player.State
{
	public class AttackingState : PlayerModelState
	{
		private readonly PlayerModel _unitController;
		private readonly UnitWeaponModel _unitWeaponModel;
		private readonly Transform _pointShot;

		public AttackingState(PlayerModel unitController, UnitWeaponModel unitWeaponModel, Transform pointShot) : base(unitController)
		{
			_unitController = unitController;
			_unitWeaponModel = unitWeaponModel;
			_pointShot = pointShot;
		}

		protected override void OnEnter(PlayerModelState prevModelState, object arg)
		{
			_unitWeaponModel.StateMachine.SetState<ReadyToFire>();
		}

		public override void Move(Vector3 pointMove)
		{
			_pointShot.LookAt(pointMove);
			
			var point = pointMove;
			point.y = _unitController.PlayerView.transform.position.y;
			
			_unitController.PlayerView.transform.LookAt(point);
		}

		protected override void OnExit(PlayerModelState nextModelState)
		{
			_unitWeaponModel.StateMachine.SetState<NotReadyToFire>();
		}
	}
}