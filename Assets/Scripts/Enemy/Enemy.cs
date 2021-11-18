using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    [HideInInspector] public Vector2 direction = Vector2.down;
    public float SPEED = 4f;
    public float RADIUS_OF_SPAWN = 3f;
    [HideInInspector] public Vector2 spawnPoint;
    public Graph graph;
    private bool enemyInitialized = false;

    //Controllers
    [HideInInspector] public EnemyMovement enemyMovement;
    EnemyAnimation enemyAnimation;
    EnemyDecisionTree enemyDecisionTree;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        spawnPoint = transform.position;
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAnimation = GetComponent<EnemyAnimation>();
        enemyDecisionTree = GetComponent<EnemyDecisionTree>();
        enemyDecisionTree.Setup(this);

        yield return new WaitUntil(() => graph.IsInitialized);

        enemyMovement.Setup(this);
        enemyInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyInitialized){
            //enemyMovement.UpdateMovement();
            enemyAnimation.UpdateAnimation(this);
            enemyDecisionTree.UpdateDecision();
        }
    }
}
