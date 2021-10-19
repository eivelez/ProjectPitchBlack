using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public void UpdateState(Enemy enemy)
    {
        if (enemy.transform.position.y >= -12)
        {
            enemy.goDown = true;
        }
        else if (enemy.transform.position.y <= -14.12)
        {
            enemy.goDown = false;
        }
    }
}
