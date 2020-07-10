using UnityEngine;

public class GunController : MonoBehaviour
{
    // if we want different weapons somehow
    public Gun CurrentGun;

    public void Shoot()
    {
        if(CurrentGun != null)
        {
            CurrentGun.Shoot();
        }
    }
}
