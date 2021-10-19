using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public bool goDown = false;
    public static float velocity = 3f;

    EnemyMovement movement;
    EnemyState state;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<EnemyMovement>();
        state = GetComponent<EnemyState>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
        UpdateMovement();
    }

    void UpdateState()
    {
        state.UpdateState(this);
    }

    void UpdateMovement()
    {
        movement.UpdateMovement(this, velocity);
    }
}
