using UnityEngine;

namespace EntitySystem.Player.State
{
	public class PlayerMove : PlayerModelState
	{
		private readonly float _speedPlayer;
		private Vector3 _target;

		public PlayerMove(PlayerModel unitController, float speedPlayer) : base(unitController)
		{
			_speedPlayer = speedPlayer;
		}

		protected override void OnEnter(PlayerModelState prevModelState, object targetPoint)
		{
			_target = (Vector3) targetPoint;
		}

		public override void Update()
		{
			if (Equals(_target, default))
				return;

			var unitView = PlayerModel.PlayerView;

			unitView.NavMeshAgent.speed = _speedPlayer;
            unitView.NavMeshAgent.SetDestination(_target);

            var target = _target;
            target.y = unitView.transform.position.y;
            
            if (Vector3.Distance(unitView.transform.position,target) > 1f)
            	return;

            _target = default;
            
            PlayerModel.PlayerView.UnitAnimator.SetTrigger("Idle");
            StateMachine.SetState<OrdersWaitingAndCheckingArea>();
		}

		public override void Move(Vector3 pointMove)
		{
			_target = pointMove;
		}
	}
}