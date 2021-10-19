using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public void UpdateMovement(Enemy enemy, float velocity)
    {
        if (enemy.goDown)
        {
            enemy.transform.Translate(Vector2.down * velocity * Time.deltaTime);
        }
        else
        {
            enemy.transform.Translate(Vector2.up * velocity * Time.deltaTime);
        }
    }
}
