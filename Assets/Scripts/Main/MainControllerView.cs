using EntitySystem.Player;
using UnityEngine;

namespace MainSystem
{
	public class MainControllerView
	{
		private Camera _camera3d;
		private PlayerController _playerController;

		public MainControllerView(PlayerController playerController, Camera camera3d)
		{
			_playerController = playerController;
			_camera3d = camera3d;
		}

		public void Tick()
		{
			UpdateMovePointAndAttack();
		}

		private void UpdateMovePointAndAttack()
		{
			if (Input.touchCount > 0)
            {
            	var touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began ||
                    touch.phase == TouchPhase.Stationary)
                {
					var ray = _camera3d.ScreenPointToRay(touch.position);
                   
	                if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
	                {
	                    _playerController.Attack();
	                    _playerController.Move(hit.point);
	                } 
                }

            	
            }
		}
	}
}