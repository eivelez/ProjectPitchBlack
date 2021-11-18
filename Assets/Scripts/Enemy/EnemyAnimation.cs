using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    public void UpdateAnimation(Enemy enemy)
    {
        animator.SetFloat("Horizontal", enemy.direction.x);
        animator.SetFloat("Vertical", enemy.direction.y);
        animator.SetFloat("Speed", enemy.direction.sqrMagnitude);
        animator.SetBool("JustAttacked", enemy.JustAttacked);
    }
}
