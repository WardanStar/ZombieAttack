using EntitySystem.Enemy;
using EntitySystem.Player;
using EntitySystem.Weapons;
using SettingsSystem;
using UnityEngine;

namespace MainSystem
{
	public class Initializer : MonoBehaviour
	{
		[SerializeField] private PlayerView _playerView;
		[SerializeField] private Camera _camera3d;
		[SerializeField] private Transform _enemySpawnPoint;
		
		public void Initialize(ref PlayerController playerController, ref MainControllerView mainControllerView, ref EnemyController enemyController)
		{
			var gameSettings = Resources.Load<GameSettings>("Settings/GameSettings");
			var weaponSettings = Resources.Load<WeaponSettings>("Settings/WeaponSettings");
			var pathToObject = Resources.Load<PathToObjectSettings>("Settings/PathToObjectSettings");
			
			var arm = new Arm(pathToObject);
			
			var player = new Player(gameSettings.Health);
			
			var resourcesWeapons = new ResourcesWeapons(weaponSettings);
			
			playerController = new PlayerController(arm, player, _playerView,
				resourcesWeapons, gameSettings.DistanceAttack, gameSettings.Speed);
			
			enemyController = new EnemyController(arm, _playerView, _enemySpawnPoint.position, gameSettings.IntervalSpawnEnemy);
			
			mainControllerView = new MainControllerView(playerController, _camera3d);
		}
	}
}