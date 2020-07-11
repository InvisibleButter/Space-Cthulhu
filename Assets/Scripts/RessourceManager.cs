using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceManager : MonoBehaviour
{
    private static RessourceManager _instance;

    public static RessourceManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public int MaxAmunition;
    public int StartAmunition;
    public int AmunitionPerCard;

    public int MaxHealth;
    public int HealthPerCard;

    public float MaxSpeed;
    public float NormalSpeed;
    public float SpeedBoostTime;

    public float ShieldTime;

    public float LightTime;

    public float MaxTickSpeed;
    public float NormalTickSpeed;
    public float TickBoostTime;

    [HideInInspector]
    public int healt;
    [HideInInspector]
    public int amunition;
    [HideInInspector]
    public float shieldTimer;
    [HideInInspector]
    public float speedBoostTimer;
    [HideInInspector]
    public float tickBoostTimer;
    [HideInInspector]
    public float lightTimer;
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float tickSpeed;

    public void Initiate()
    {
        healt = MaxHealth;
        amunition = StartAmunition;
        shieldTimer = 0;
        speedBoostTimer = 0;
        tickBoostTimer = 0;
        lightTimer = LightTime;
        speed = NormalSpeed;
        tickSpeed = NormalTickSpeed;
    }

    public void RessourceUpdate()
    {
        //speed
        if (speedBoostTimer > 0)
        {
            speedBoostTimer -= Time.deltaTime;
            speed = MaxSpeed;
        }
        if (speedBoostTimer == 0 && speed == MaxSpeed)
            speed = NormalSpeed;
        if (speedBoostTimer < 0)
        {
            speed = NormalSpeed;
            speedBoostTimer = 0;
        }

        //tick
        if (tickBoostTimer > 0)
        {
            tickBoostTimer -= Time.deltaTime;
            tickSpeed = MaxTickSpeed;
        }
        if (tickBoostTimer == 0 && tickSpeed == MaxTickSpeed)
            tickSpeed = NormalTickSpeed;
        if (tickBoostTimer < 0)
        {
            tickSpeed = NormalTickSpeed;
            tickBoostTimer = 0;
        }

    }

}
