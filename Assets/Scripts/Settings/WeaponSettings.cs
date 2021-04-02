using System;
using System.Collections.Generic;
using Abstract;
using UnityEngine;

namespace SettingsSystem
{
	[CreateAssetMenu()]
	public class WeaponSettings : ScriptableObject
	{
		[Serializable]
		public struct WeaponsInfo
		{
			public TypeWeapons TypeWeapons;
			public float PowerImpactShell;
			public string PathToShell;
			public float RateOfFire;
		}

		public List<WeaponsInfo> WeaponsInfos => _weaponsInfos;
		[SerializeField] private List<WeaponsInfo> _weaponsInfos = new List<WeaponsInfo>();
	}
}