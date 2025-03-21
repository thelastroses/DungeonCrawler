using UnityEngine;

public class Fight 
{
    private Inhabitant attacker;
    private Inhabitant defender;

    public Fight()
    {
        int roll = Random.Range(0, 20) + 1;
        if (roll <= 10)
        {
            Debug.Log("Monster goes first");
            this.attacker = Core.theMonster;
            this.defender = Core.thePlayer;
        }
        else
        {
            Debug.Log("Player goes first");
            this.attacker = Core.thePlayer;
            this.defender = Core.theMonster;
        }

    }

    public void startFight()
    {
        //should have the attacker and defender fight each until one of them dies.
        //the attacker and defender should alternate between each fight round and
        //the one who goes first was determined in the constructor.

        //print to command line //like deathmatch

        Debug.Log("Attacker: " + this.attacker.getName() + " MaxHP: " + this.attacker.getMaxHp() + " CurrHp:" + this.attacker.getCurrHP() + " AC:" + this.attacker.getAC());
        Debug.Log("Defender: " + this.defender.getName() + " MaxHP: " + this.defender.getMaxHp() + " CurrHp:" + this.defender.getCurrHP() + " AC:" + this.defender.getAC());

        while (this.defender.getCurrHP() > 0 && this.attacker.getCurrHP() > 0)
        {
            Debug.Log(this.defender.getName() + " CurrHp:" + this.defender.getCurrHP());
            Debug.Log(this.attacker.getName() + " CurrHp:" + this.attacker.getCurrHP());

            int mayAttack = UnityEngine.Random.Range(10, 20);
            if (mayAttack >= defender.getAC())
            {
                int damage = UnityEngine.Random.Range(5, 15);
                this.defender.setCurrHp(this.defender.getCurrHP() - damage);

                Debug.Log(this.attacker.getName() + " attacks " + this.defender.getName() + " for " + damage);

                if (this.defender.getCurrHP() <= 0)
                {
                    Debug.Log(this.defender.getName() + " died and " + this.attacker.getName() + " won!");
                }
            }
            else
            {
                Debug.Log(this.attacker.getName() + " missed his attack");
            }

            Inhabitant cuurAttacker = attacker;
            attacker = defender;
            defender = cuurAttacker;
        }
    }
}