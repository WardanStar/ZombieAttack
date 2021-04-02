using UnityEngine;

namespace EntitySystem.Weapons.State
{
	public class DelayBeforeShots : UnitWeaponModelState
	{
		private float _timeNextShot;

		public DelayBeforeShots(UnitWeaponModel unitWeaponModel) : base(unitWeaponModel)
		{
		}

		protected override void OnEnter(UnitWeaponModelState prevState, object arg)
        {
        	_timeNextShot = Time.time + 100 / UnitWeaponModel.ResourcesWeapons.CurrentWeapons.WeaponsInfo.RateOfFire;
        }
		
		public override void Update()
		{
			if (Time.time < _timeNextShot)
            	return;
            
            StateMachine.SetState<ReadyToFire>();
		}
	}
}