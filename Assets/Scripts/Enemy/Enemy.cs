using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public bool goDown = false;
    public static float velocity = 3f;

    EnemyMovement movement;
    EnemyState state;
    EnemyAnimation enemyAnimation;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<EnemyMovement>();
        state = GetComponent<EnemyState>();
        enemyAnimation = GetComponent<EnemyAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.UpdateMovement(this, velocity);
        state.UpdateState(this);
        enemyAnimation.UpdateAnimation(this);
    }
}
