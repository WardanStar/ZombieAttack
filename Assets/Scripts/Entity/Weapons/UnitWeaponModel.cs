using EntitySystem.Weapons.State;
using Game.Common.StateMachines;
using MainSystem;
using UnityEngine;

namespace EntitySystem.Weapons
{
	public class UnitWeaponModel
	{
		public readonly StateMachine<UnitWeaponModelState> StateMachine;
		public readonly ResourcesWeapons ResourcesWeapons;
		public readonly Arm Arm;

		public UnitWeaponModel(ResourcesWeapons resourcesWeapons, Arm arm, Transform pointShot)
		{
			ResourcesWeapons = resourcesWeapons;
			Arm = arm;

			StateMachine = new StateMachine<UnitWeaponModelState>();
			
			StateMachine.SetStates(new UnitWeaponModelState[]
			{
				new NotReadyToFire(this), 
				new ReadyToFire(this, pointShot), 
				new DelayBeforeShots(this) 
			});
			
			StateMachine.SetState<NotReadyToFire>();
		}
	}
}