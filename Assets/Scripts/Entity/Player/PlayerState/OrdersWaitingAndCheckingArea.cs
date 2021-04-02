using UnityEngine;

namespace EntitySystem.Player.State
{
	public class OrdersWaitingAndCheckingArea : PlayerModelState
	{
		private readonly LayerMask _enemyLayer;
		private readonly LayerMask _attackZoneLayer;
		private readonly float _distanceAttack;
		
		public OrdersWaitingAndCheckingArea(PlayerModel unitController, float distanceAttack) : base(unitController)
        {
	        _enemyLayer = LayerMask.GetMask("Enemy");
	        _attackZoneLayer = LayerMask.GetMask("ZoneAttack");
	        _distanceAttack = distanceAttack;
        }

		protected override void OnEnter(PlayerModelState prevModelState, object arg)
		{
		}

		public override void Update()
		{ 
			Transform playerTransform = PlayerModel.PlayerView.gameObject.transform;

         	if (!Physics.CheckSphere(playerTransform.position, 5f, _attackZoneLayer) ||
         	    !Physics.CheckSphere(playerTransform.position, _distanceAttack, _enemyLayer))
	            return;
            
            PlayerModel.PlayerView.UnitAnimator.SetTrigger("AttackState");
            StateMachine.SetState<AttackingState>();
		}

		public override void Move(Vector3 pointMove)
		{
			PlayerModel.PlayerView.UnitAnimator.SetTrigger("Move");
			StateMachine.SetState<PlayerMove>(pointMove);
		}
	}
}