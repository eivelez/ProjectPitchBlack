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
        root = TreeConstruction();
    }

    private ObjectDecision TreeConstruction(){
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
