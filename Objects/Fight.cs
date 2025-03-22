using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;

    public TextMeshProUGUI MonsterHealth;
    public TextMeshProUGUI PlayerHealth;

    public bool fightIsOver = false;

    public Fight(TextMeshProUGUI monsterHealth, TextMeshProUGUI playerHealth)
    {
        MonsterHealth = monsterHealth;
        PlayerHealth = playerHealth;
    }

    public void SetUpFight()
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
        Debug.Log("Attacker: " + this.attacker.getName() + " MaxHP: " + this.attacker.getMaxHp() + " CurrHp:" + this.attacker.getCurrHP() + " AC:" + this.attacker.getAC());
        Debug.Log("Defender: " + this.defender.getName() + " MaxHP: " + this.defender.getMaxHp() + " CurrHp:" + this.defender.getCurrHP() + " AC:" + this.defender.getAC());
    }



    public void startFight(GameObject playerGameObject, GameObject monsterGameObject)
    {
        //should have the attacker and defender fight each until one of them dies.
        //the attacker and defender should alternate between each fight round and
        //the one who goes first was determined in the constructor.

        if (fightIsOver) return;

        Debug.Log(this.defender.getName() + " CurrHp:" + this.defender.getCurrHP());
        Debug.Log(this.attacker.getName() + " CurrHp:" + this.attacker.getCurrHP());


        int mayAttack = UnityEngine.Random.Range(10, 20);
        if (mayAttack >= defender.getAC())
        {
            int damage = UnityEngine.Random.Range(5, 15);
            this.defender.takeDamage(damage);

            Debug.Log(this.attacker.getName() + " attacks " + this.defender.getName() + " for " + damage);

            if (this.defender.getCurrHP() <= 0)
            {
                Debug.Log(this.defender.getName() + " died and " + this.attacker.getName() + " won!");
                if (this.defender is Player)
                {
                    Debug.Log("Player died");
                    playerGameObject.SetActive(false);
                }
                else
                {
                    Debug.Log("Monster died");
                    GameObject.Destroy(monsterGameObject);
                }
                fightIsOver = true;
                return;
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

    public void Health()
    {
        PlayerHealth.text = "Player Health: " + Core.thePlayer.getCurrHP();
        MonsterHealth.text = "Monster Health: " + Core.theMonster.getCurrHP();
    }
}