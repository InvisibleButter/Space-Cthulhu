﻿using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : Entity
{

	public float moveSpeed = 5;
	private PlayerController _playerController;
	private GunController _gunController;

	protected override void Start()
	{
		base.Start();

		_playerController = GetComponent<PlayerController>();
		_gunController = GetComponent<GunController>();
	}

	void Update()
	{
		//hanlde move and rotation
		float x = Input.GetAxisRaw("Horizontal");
		float z = Input.GetAxisRaw("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;
		Vector3 moveVelocity = move.normalized * moveSpeed;

		_playerController.Move(moveVelocity);
		_playerController.Rotate();

		// handle shooting
		if(Input.GetMouseButton(0))
		{
			_gunController.Shoot();
		}
	}

	public override void Die()
	{
		base.Die();
	}
}