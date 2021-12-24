using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature
{
    private string name;
    private ushort health;
    private ushort attack;
    private ushort defense;
    private ushort spDefense;
    private ushort spAttack;
    private ushort speed;
    private string desc;
    private List<PowerType> powerTypes;


    public Creature(string name, ushort health, ushort attack, ushort defense, ushort spDefense, ushort spAttack, ushort speed, string desc, PowerType type, PowerType type2)
    {
        this.name = name;
        this.health = health;
        this.attack = attack;
        this.defense = defense;
        this.spDefense = spDefense;
        this.spAttack = spAttack;
        this.speed = speed;
        this.desc = desc;
        this.powerTypes.Add(type);
        this.powerTypes.Add(type2);
    }

    public string getName()
    {
        return name;
    }
    public ushort getHealth()
    {
        return health;
    }
    public ushort getAttack()
    {
        return attack;
    }
    public ushort getDefense()
    {
        return defense;
    }
    public ushort getSpDefense()
    {
        return spDefense;
    }
    public ushort getspAttack()
    {
        return spAttack;
    }
    public ushort getSpeed()
    {
        return speed;
    }
    public string getDesc()
    {
        return desc;
    }
    public List<PowerType> getTypes()
    {
        return powerTypes;
    }
}
