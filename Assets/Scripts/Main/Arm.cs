using ResourcesLoadSystem;
using SettingsSystem;
using ToolsSystem;
using UnityEngine;

namespace MainSystem
{
	public class Arm
	{
		public readonly PathToObjectSettings PathToObjectSettings;
		public readonly GetObjectManager GetObjectManager;

		public Arm(PathToObjectSettings pathToObjectSettings)
		{
			PathToObjectSettings = pathToObjectSettings;
			
			GetObjectManager = new GetObjectManager(new ResourceLoadManager(),
				new PoolManager() , new GameObject("MonoBehaviourManager").AddComponent<MonoBehaviourManager>());
		} 
	}
}