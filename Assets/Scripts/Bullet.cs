using UnityEngine;

public class Bullet : MonoBehaviour
{
	float speed = 10;
	public LayerMask Mask;
	public int Damage = 1;
	public int LifeTime = 5;

	private float _skinWidth = 0.1f;

	private void Start()
	{
		Destroy(gameObject, LifeTime);
	}

	public void SetSpeed(float newSpeed)
	{
		speed = newSpeed;
	}

	void Update()
	{
		float moveDist = Time.deltaTime * speed;
		CheckCollision(moveDist);
		transform.Translate(Vector3.forward * moveDist);
	}

	private void CheckCollision(float moveDist)
	{
		Ray r = new Ray(transform.position, transform.forward);
		RaycastHit hit;

		if(Physics.Raycast(r, out hit, moveDist + _skinWidth, Mask, QueryTriggerInteraction.Collide))
		{
			IDamageable damagedObj = hit.collider.GetComponent<IDamageable>();
			if(damagedObj != null)
			{
				damagedObj.Hit(Damage, hit);
			}
		}
	}
}
