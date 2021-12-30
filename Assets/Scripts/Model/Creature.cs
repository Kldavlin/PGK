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
    private uint currentExp;
    private byte level;
    private uint lvlUpExp;


    public Creature(string name, ushort health, ushort attack, ushort defense, ushort spDefense, ushort spAttack, ushort speed, string desc, PowerType type, PowerType type2, byte level)
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
        this.currentExp = 0;
        this.level = level;
        this.lvlUpExp = 100; //TODO: figure out an equation to determine this
    }

    public string getName()
    {
        return name;
    }
    public ushort getHealth()
    {
        return getScaledStat(health);
    }
    public ushort getAttack()
    {
        return getScaledStat(attack);
    }
    public ushort getDefense()
    {
        return getScaledStat(defense);
    }
    public ushort getSpDefense()
    {
        return getScaledStat(spDefense);
    }
    public ushort getspAttack()
    {
        return getScaledStat(spAttack);
    }
    public ushort getSpeed()
    {
        return getScaledStat(speed);
    }
    public string getDesc()
    {
        return desc;
    }
    public List<PowerType> getTypes()
    {
        return powerTypes;
    }
    public byte getLevel()
    {
        return level;
    }
    public uint getExp()
    {
        return currentExp;
    }

    public void gainExp(ushort exp)
    {
        currentExp += exp;
        if(currentExp > lvlUpExp)
        {
            levelUp();
        }
    }

    private void levelUp()
    {
        level++;
    }

    private ushort getScaledStat(ushort stat)
    {
        return (ushort)(stat * level / Constants.MAX_LEVEL);
    }
}
