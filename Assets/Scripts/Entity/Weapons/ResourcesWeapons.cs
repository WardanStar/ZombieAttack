using System.Collections.Generic;
using Abstract;
using SettingsSystem;

namespace EntitySystem.Weapons
{
	public class ResourcesWeapons
	{
		public ResourcesWeaponsInfo CurrentWeapons { get; private set; }
		
		private readonly List<ResourcesWeaponsInfo> _resourcesWeapons = new List<ResourcesWeaponsInfo>();
		
		public ResourcesWeapons(WeaponSettings weaponSettings)
		{
			foreach (var weaponsInfo in weaponSettings.WeaponsInfos)
			{
				_resourcesWeapons.Add(new ResourcesWeaponsInfo(weaponsInfo));
			}
			
			GetWeapons(TypeWeapons.AutomaticGun);
		}
		
		public class ResourcesWeaponsInfo
		{
			public WeaponSettings.WeaponsInfo WeaponsInfo;
            public int QuantityOfRemainingShellsToClip;
            public int QuantityOfRemainingShells;
    
            public ResourcesWeaponsInfo(WeaponSettings.WeaponsInfo weaponsInfo)
            {
	            WeaponsInfo = weaponsInfo;
            }
		}

		public void GetWeapons(TypeWeapons typeWeapons)
		{
			foreach (ResourcesWeaponsInfo resourcesWeaponsInfo in _resourcesWeapons)
			{
				if (resourcesWeaponsInfo.WeaponsInfo.TypeWeapons != typeWeapons)
					continue;

				CurrentWeapons = resourcesWeaponsInfo;
			}
		}
	}
}