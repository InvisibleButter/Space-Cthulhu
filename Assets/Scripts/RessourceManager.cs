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
    public float SlowSpeed;
    public float SlowSpeedTime;
    public float SpeedBoostTime;

    public float ShieldTime;

    public float LightTime;

    public float MaxTickSpeed;
    public float NormalTickSpeed;
    public float TickBoostTime;
    public float TickStopTime;

    public int DMG;

    public int ResDownAmmunition;
    public int ResDownLight;
    public int ResDownShield;

    [HideInInspector]
    public int health;
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
    [HideInInspector]
    public float slowSpeedTimer;
    [HideInInspector]
    public float tickStopTimer;

    public void Initiate()
    {
        health = MaxHealth;
        amunition = StartAmunition;
        shieldTimer = 0;
        speedBoostTimer = 0;
        tickBoostTimer = 0;
        lightTimer = LightTime;
        speed = NormalSpeed;
        tickSpeed = NormalTickSpeed;
        slowSpeedTimer = 0;
        tickStopTimer = 0;
    }

    public void RessourceUpdate()
    {
        //speed
        if (slowSpeedTimer > 0)
        {
            slowSpeedTimer -= Time.deltaTime;
            speedBoostTimer = 0;
            speed = SlowSpeed;
        }
        else
        {
            slowSpeedTimer = 0;
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
        }



        //tick
        if (tickStopTimer > 0)
        {
            slowSpeedTimer -= Time.deltaTime;
            tickBoostTimer = 0;
            tickSpeed = 0;
        }
        else
        {
            tickStopTimer = 0;
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

        Debug.Log(amunition);
    }

    public void SpeedBoost()
    {
        speedBoostTimer = SpeedBoostTime;
    }
    public void TickBoost()
    {
        tickBoostTimer = TickBoostTime;
    }
    public void SpeedSlow()
    {
        slowSpeedTimer = SlowSpeedTime;
    }
    public void TickStop()
    {
        tickStopTimer = TickStopTime;
    }
    public void DealDamage()
    {
        if(shieldTimer<=0)
            health -= DMG;
    }
    public void DealDamage(int amount)
    {
        if (shieldTimer <= 0)
            health -= amount;
    }
    public void Heal()
    {
        if (health + HealthPerCard > MaxHealth)
            health = MaxHealth;
        else
            health += HealthPerCard;
    }
    public void Reloade()
    {
        if (amunition + AmunitionPerCard > MaxAmunition)
            amunition = MaxAmunition;
        else
            amunition += AmunitionPerCard;
    }
    public void RefillLight()
    {
        lightTimer += LightTime;
    }
    public void RefillShield()
    {
        shieldTimer += ShieldTime;
    }
    public void SteelResources()
    {
        if (amunition - ResDownAmmunition > 0)
            amunition -= ResDownAmmunition;
        else
            amunition = 0;


        if (lightTimer - ResDownLight > 0)
            lightTimer -= ResDownLight;
        else
            lightTimer = 0;


        if (shieldTimer - ResDownShield > 0)
            shieldTimer -= ResDownShield;
        else
            shieldTimer = 0;
    }
}
