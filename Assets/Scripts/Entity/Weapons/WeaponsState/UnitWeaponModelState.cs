using Game.Common.StateMachines;

namespace EntitySystem.Weapons.State
{
	public abstract class UnitWeaponModelState : State<UnitWeaponModelState>
	{
		protected UnitWeaponModel UnitWeaponModel;
		
		protected UnitWeaponModelState(UnitWeaponModel unitWeaponModel)
		{
			UnitWeaponModel = unitWeaponModel;
		}
		
		public virtual void Attack(){}
		public virtual void Update(){}
	}
}