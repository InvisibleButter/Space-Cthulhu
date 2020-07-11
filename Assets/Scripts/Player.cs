using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : Entity
{
	private PlayerController _playerController;
	private GunController _gunController;

	protected override void Start()
	{
		base.Start();

		_playerController = GetComponent<PlayerController>();
		_gunController = GetComponent<GunController>();
		_currenthealth = RessourceManager.Instance.health;
	}

	void Update()
	{
		//handle move and rotation
		float x = Input.GetAxisRaw("Horizontal");
		float z = Input.GetAxisRaw("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;
		Vector3 moveVelocity = move.normalized * RessourceManager.Instance.speed;

		_playerController.Move(moveVelocity);
		_playerController.Rotate();

		// handle shooting
		if(Input.GetMouseButton(0))
		{
			_gunController.Shoot();
		}
		if(Input.GetKey(KeyCode.R))
		{
			_gunController.Reload();
		}
	}

	public override void Hit(int amount)
	{
		RessourceManager.Instance.DealDamage();
		_currenthealth = RessourceManager.Instance.health;

		if(_currenthealth <= 0)
		{
			Die();
		}
	}

	public override void Die()
	{
		//todo some crazy shit here
	}
}