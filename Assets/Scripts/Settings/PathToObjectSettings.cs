using UnityEngine;

namespace SettingsSystem
{
	[CreateAssetMenu()]
	public class PathToObjectSettings : ScriptableObject
	{
		public string PathToZombie => pathToZombie;
		public string PathToZombieRagdoll => pathToZombieRagdoll;

		[SerializeField] private string pathToZombie;
		[SerializeField] private string pathToZombieRagdoll;
	}
}