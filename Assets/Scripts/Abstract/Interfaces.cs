namespace Abstract
{
	public interface ILive
	{
		float Health { get; }

		public void GetDamaged(float damage);
	}

	public interface IWeapons
	{
		string PathToShell { get; }
		float IntervalBetweenShots { get; }
		float QuantityShells { get; }
		float Damage { get; }
		
		bool ReadyToFire();
	}

	
}