public class Enemy : Entity
{
    protected override void Start()
    {
        base.Start();
    }

    public override void Die()
    {
        base.Die();
        //ping enemy-spawner to update the spawn
        gameObject.SetActive(false);
    }
}
