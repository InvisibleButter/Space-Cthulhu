using UnityEngine;

public class Gun : MonoBehaviour
{
	public Transform muzzle;
	public Bullet projectile;
	public float msBetweenShots = 100;
	public float muzzleVelocity = 35;

	float nextShotTime;

	public void Shoot()
	{

		if (Time.time > nextShotTime)
		{
			nextShotTime = Time.time + msBetweenShots / 1000;
			Bullet bullet = Instantiate(projectile, muzzle.position, muzzle.rotation) as Bullet;
			bullet.SetSpeed(muzzleVelocity);
		}
	}
}
