using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public Transform Muzzle;
	public Bullet Projectile;
	public float _msBetweenShots = 100f;
	public float _muzzleVelocity = 35f;

	public float ReloadTime = 3.5f;
	public int MaxAmmoPerMag = 10;

	private float _nextShotTime;

	private bool _hasToReload, _isReloading;
	private int _shootsRemaining;
	private int _currentMaxAmmo = 20;


	private void Start()
	{
		_shootsRemaining = GetMagCount();
	}

	private int GetMagCount()
	{
		if( _currentMaxAmmo - MaxAmmoPerMag >= 0)
		{
			_currentMaxAmmo -= MaxAmmoPerMag;
			return MaxAmmoPerMag;
		}
		int max = _currentMaxAmmo;

		_currentMaxAmmo = 0;
		return max;
	}

	public void Shoot()
	{

		if (!_isReloading && Time.time > _nextShotTime && _shootsRemaining > 0)
		{
			Debug.Log("** shoot");
			_shootsRemaining--;
			_nextShotTime = Time.time + _msBetweenShots / 1000;
			Bullet bullet = Instantiate(Projectile, Muzzle.position, Muzzle.rotation, GunController.Instance.BulletHolder) as Bullet;
			bullet.SetSpeed(_muzzleVelocity);

			if(_shootsRemaining == 0)
			{
				_hasToReload = true;
				GunController.Instance.ToggleReloadInfo(true);
			}
		}
	}

	public void Reload() 
	{ 
		if(_hasToReload && !_isReloading)
		{
			StartCoroutine(WaitToReload());
		}
	}

	private IEnumerator WaitToReload()
	{
		_isReloading = true;

		yield return new WaitForSeconds(ReloadTime);

		_shootsRemaining = GetMagCount();
		Debug.Log("** remaining shoots: " + _shootsRemaining);
		_hasToReload = _shootsRemaining > 0;
		GunController.Instance.ToggleReloadInfo(false);
		_isReloading = false;
	}

	public void IncreaseMaxAmmo(int val)
	{
		_currentMaxAmmo += val;
	}

	public void DecreaseMaxAmmo(int val)
	{
		_currentMaxAmmo -= val;
		if(_currentMaxAmmo <= 0)
		{
			_currentMaxAmmo = 0;
		}
	}
}
