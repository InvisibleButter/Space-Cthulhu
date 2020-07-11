using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card 
{
    
    public enum CardType
    {
        Amunition=0,
        Healing=1,
        Light=2,
        Speed=3,
        Shield=4,
        Repair=5,
        Overclocking=6
    }
    public CardType type;
    public bool positive;

    public void setCardType(CardType type)
    {
        this.type = type;
    }

    public CardType getCardType()
    {
        return type;
    }

    public abstract void Action(float f);

    public void setPositive(bool p)
    {
        positive = p;
    }
    public bool isPositive()
    {
        return positive;
    }
}



public class AmunitionCard : Card
{
    
    public AmunitionCard()
    {
        setCardType(CardType.Amunition);
        setPositive(true);
    }

    public override void Action(float amount)
    {
        Debug.Log("Munition Nachladen, Animationen und Effekte abspielen");
    }
}
public class HealingCard : Card
{
    public HealingCard()
    {
        setCardType(CardType.Healing);
        setPositive(true);
    }

    public override void Action(float amount)
    {
        Debug.Log("Healing");
    }
}
public class LightCard : Card
{
    public LightCard()
    {
        setCardType(CardType.Light);
        setPositive(true);
    }

    public override void Action(float time)
    {
        Debug.Log("Light");
    }
}
public class SpeedCard : Card
{
    public SpeedCard()
    {
        setCardType(CardType.Speed);
        setPositive(true);
    }

    public override void Action(float time)
    {
        Debug.Log("Speed");
    }
}
public class ShieldCard : Card
{
    public ShieldCard()
    {
        setCardType(CardType.Shield);
        setPositive(true);
    }

    public override void Action(float time)
    {
        Debug.Log("Shieldup");
    }
}
public class RepairCard : Card
{
    public RepairCard()
    {
        setCardType(CardType.Repair);
        setPositive(true);
    }

    public override void Action(float notNeeded)
    {
        Debug.Log("repair");
    }
}

public class OverclockingCard : Card
{
    public OverclockingCard()
    {
        setCardType(CardType.Overclocking);
        setPositive(true);
    }

    public override void Action(float time)
    {
        Debug.Log("overclocking");
    }
}
