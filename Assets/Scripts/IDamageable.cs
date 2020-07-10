using UnityEngine;

public interface IDamageable
{
    void Hit(int amount, RaycastHit hit);

    void IncreaseHealth(int amount);

    void Die();
}
