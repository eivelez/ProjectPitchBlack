using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public Vector2 direction = Vector2.down;
    public float SPEED = 4f;
    public Graph graph;

    //Controllers
    EnemyMovement movement;
    EnemyState state;
    EnemyAnimation enemyAnimation;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        movement = GetComponent<EnemyMovement>();
        state = GetComponent<EnemyState>();
        enemyAnimation = GetComponent<EnemyAnimation>();

        yield return new WaitUntil(() => graph.IsInitialized);

        movement.Setup(this);
    }

    // Update is called once per frame
    void Update()
    {
        movement.UpdateMovement();
        state.UpdateState(this);
        enemyAnimation.UpdateAnimation(this);
    }
}
