using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    public int MaxHealth = 10;

    private int _currenthealth;
    private bool _isDead;

    protected virtual void Start()
    {
        _currenthealth = MaxHealth;
    }

    public void Hit(int amount, RaycastHit hit)
    {
        UnityEngine.Debug.Log("*** Entity was hitted");
        _currenthealth -= amount;
        if(_currenthealth <= 0 && !_isDead)
        {
            Die();
        }
    }

    public void IncreaseHealth(int amount)
    {
        _currenthealth += amount;
        if(_currenthealth > MaxHealth)
        {
            _currenthealth = MaxHealth;
        }
    }

    public virtual void Die()
    {
        //override to handle enemies and players on their own
    }
}
