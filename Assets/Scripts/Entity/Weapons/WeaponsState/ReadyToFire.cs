using UnityEngine;

namespace EntitySystem.Weapons.State
{
	public class ReadyToFire : UnitWeaponModelState
	{
		private readonly Transform _pointShot;

		public ReadyToFire(UnitWeaponModel unitWeaponModel, Transform pointShot) : base(unitWeaponModel)
		{
			_pointShot = pointShot;
		}
		
		public override void Attack()
		{
			var shell = UnitWeaponModel.Arm.GetObjectManager.GetObject<ShellController>(
				UnitWeaponModel.ResourcesWeapons.CurrentWeapons.WeaponsInfo.PathToShell, _pointShot.position, _pointShot.rotation, 10f);
			
			shell.Assign(UnitWeaponModel.ResourcesWeapons.CurrentWeapons.WeaponsInfo.PowerImpactShell);
			StateMachine.SetState<DelayBeforeShots>();
		}
	}
}