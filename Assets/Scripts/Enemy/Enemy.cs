using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    [HideInInspector] public Vector2 direction = Vector2.down;
    public float SPEED = 4f;
    public float RADIUS_OF_SPAWN = 0.5f;
    [SerializeField] private float SECONDS_BEFORE_MOVING_AGAIN = 3f;
    [HideInInspector] public Vector2 spawnPoint;
    public Graph graph;
    private bool enemyInitialized = false;
    private bool justAttacked = false;
    private CapsuleCollider2D enemyCollider;
    [HideInInspector] public bool JustAttacked
    {
        get { return justAttacked; }
        set
        {
            if (value == true)
            {
                enemyCollider.enabled = false;
                StartCoroutine(DelayEnemyActivity());
            }
            justAttacked = value;
        }
    }

    //Controllers
    [HideInInspector] public EnemyMovement enemyMovement;
    EnemyAnimation enemyAnimation;
    EnemyDecisionTree enemyDecisionTree;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        spawnPoint = transform.position;
        enemyCollider = GetComponent<CapsuleCollider2D>();
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
            enemyAnimation.UpdateAnimation(this);
            enemyDecisionTree.UpdateDecision();
        }
    }

    private IEnumerator DelayEnemyActivity(){
        yield return new WaitForSeconds(SECONDS_BEFORE_MOVING_AGAIN);
        enemyCollider.enabled = true;
        JustAttacked = false;
    }
}
