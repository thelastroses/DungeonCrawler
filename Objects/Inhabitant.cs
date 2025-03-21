using UnityEngine;

public abstract class Inhabitant
{
    protected int currHp;
    protected int maxHp;
    protected int ac;
    protected string name;

    public Inhabitant(string name)
    {
        this.name = name;
        this.maxHp = Random.Range(30, 50);
        this.currHp = this.maxHp;
        this.ac = Random.Range(10, 20);
    }

    public int getCurrHP()
    {
        return this.currHp;
    }

    public string getName()
    {
        return this.name;
    }

    public int getMaxHp()
    {
        return this.maxHp;

    }
    public int getAC()
    {
        return this.ac;
    }



    public void setCurrHp(int hp)
    {
        this.currHp = hp;
    }
}