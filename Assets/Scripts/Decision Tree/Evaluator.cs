using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Evaluator
{
    public abstract bool Evaluate();
}

//--------------------------------------------------------------
//Enemy evaluators
public class IsPlayerNearEnemy : Evaluator
{
    GameObject player;
    GameObject enemy;
    float DISTANCE_TO_BE_NEAR = 5f;


    public IsPlayerNearEnemy(GameObject player, GameObject enemy){
        this.player = player;
        this.enemy = enemy;
    }

    public override bool Evaluate()
    {
        return (Vector2.Distance(player.transform.position, enemy.transform.position) <= DISTANCE_TO_BE_NEAR);
    }
}


public class IsEnemyFarFromSpawnPoint : Evaluator
{
    Vector2 spawnPoint;
    GameObject enemy;


    public IsEnemyFarFromSpawnPoint(Vector2 spawnPoint, GameObject enemy){
        this.spawnPoint = spawnPoint;
        this.enemy = enemy;
    }

    public override bool Evaluate()
    {
        return (Vector2.Distance(spawnPoint, enemy.transform.position) > enemy.GetComponent<Enemy>().RADIUS_OF_SPAWN);
    }
}

public class IsPlayerHiding : Evaluator
{
    GameObject player;

    public IsPlayerHiding(GameObject player){
        this.player = player;
    }

    public override bool Evaluate()
    {
        return (player.GetComponent<Player>().isHiding);
    }
}

