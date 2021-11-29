using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDecisionTree : MonoBehaviour
{
    Enemy enemy;
    ObjectDecision root;

    public void Setup(Enemy enemy)
    {
        this.enemy = enemy;
        
        //We see the tag if it is the boss or a common enemy:
        if (enemy.tag == "Boss")
        {
            root = BossTreeConstruction();
        }
        else
        {
            root = EnemyTreeConstruction();
        }
    }

    private ObjectDecision EnemyTreeConstruction(){
        //Decisions
        ObjectDecision playerNear = new ObjectDecision(new IsPlayerNearEnemy(enemy.player, gameObject));
        ObjectDecision playerHiding = new ObjectDecision(new IsPlayerHiding(enemy.player));
        ObjectDecision spawnPointFarAway = new ObjectDecision(new IsEnemyFarFromSpawnPoint(enemy.spawnPoint, gameObject));

        //Actions
        ActionNode roam = new ActionNode("Roam");
        ActionNode attack = new ActionNode("Attack");
        ActionNode returnToSpawn = new ActionNode("Return");
        
        //Tree assembly
        playerNear.yesNode = playerHiding;
        playerNear.noNode = spawnPointFarAway;

        playerHiding.yesNode = returnToSpawn;
        playerHiding.noNode = attack;

        spawnPointFarAway.yesNode = returnToSpawn;
        spawnPointFarAway.noNode = roam;

        ObjectDecision root = playerNear;
        return root;
    }

    private ObjectDecision BossTreeConstruction()
    {
        //Its a very simple tree because the boss will ALWAYS attack the player

        //Decisions
        ObjectDecision playerHiding = new ObjectDecision(new IsPlayerHiding(enemy.player));
        //Actions
        ActionNode attack = new ActionNode("Attack");
        
        //Tree assembly
        playerHiding.yesNode = null;
        playerHiding.noNode = attack;

        ObjectDecision root = playerHiding;
        return root;
    }

    public void UpdateDecision()
    {
        //Check first if the enemy just attacked the player to give it time to escape
        if (enemy.JustAttacked){
            return;
        }

        ActionNode result = (ActionNode) root.Decide();
        //Debug.Log(result.name);

        switch (result.name)
        {
            case "Roam":
                enemy.enemyMovement.Roam();
                break;

            case "Attack":
                enemy.enemyMovement.Attack();
                break;

            case "Return":
                enemy.enemyMovement.Return();
                break;
        }
    }
}
