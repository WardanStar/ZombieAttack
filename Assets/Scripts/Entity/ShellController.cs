using InitializeSystem;
using UnityEngine;

namespace EntitySystem
{
	public class ShellController : MonoBehaviour, IInitialize<float>
	{
		[SerializeField] private float _speedShell;
		[SerializeField] private float _damage;
		private Vector3 _dictionary;
		private float _powerImpact;

		public void Assign(float powerImpact)
		{
			_powerImpact = powerImpact;
		}
		
		private void Start()
		{
			_dictionary = Vector3.forward * _speedShell;
		}

		private void Update()
		{
			if (!Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, _speedShell * Time.deltaTime))
			{
				transform.Translate(_dictionary * Time.deltaTime);
				return;
			}

			if (hitInfo.collider.tag != "Enemy")
				return;
			
			hitInfo.collider.GetComponent<Enemy.Enemy>().GetDamaged(_damage, _powerImpact);
			gameObject.SetActive(false);
		}


		
	}
}