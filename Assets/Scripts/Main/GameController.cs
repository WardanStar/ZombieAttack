using EntitySystem.Enemy;
using EntitySystem.Player;
using UnityEngine;

namespace MainSystem
{
	public class GameController : MonoBehaviour
	{
		private PlayerController _playerController;
		private MainControllerView _mainControllerView;
		private EnemyController _enemyController;
		
		[SerializeField] private Initializer _initializer;

		private void Awake()
		{
			_initializer.Initialize(ref _playerController, ref _mainControllerView, ref _enemyController);
		}

		private void Update()
		{
			_playerController.Tick();
			_mainControllerView.Tick();
			_enemyController.Tick();
		}
	}
}