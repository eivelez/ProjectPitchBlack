using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Enemy enemy;
    [SerializeField] private GameObject player;
    private List<Node> pathToPlayer = new List<Node>();
    private bool timerBool = true;

    public void Setup(Enemy enemy){
        this.enemy = enemy;
        pathToPlayer = enemy.graph.PathFinding(this.transform.position, player.transform.position);
    }

    public void UpdateMovement()
    {
        if (pathToPlayer.Count == 0){
            return;
        }

        if (timerBool){
            Invoke("RecalculatePathFinding", 1f);
            timerBool = false;
        }

        GoToPoint(pathToPlayer[pathToPlayer.Count-1]);
    }

    private void RecalculatePathFinding(){
        pathToPlayer = enemy.graph.RecalculatePathFinding(this.transform.position, player.transform.position);
        timerBool = true;
    }

    private void GoToPoint(Node node)
    {
        //We check if enemy reached node to go to the next one, if so we remove it from the list
        if (Vector3.Distance(node.GetPosition(), transform.position) < 0.1f)
        {
            pathToPlayer.RemoveAt(pathToPlayer.Count-1);
            return;
        }

        //A vector for the animations
        enemy.direction = (node.GetPosition() - transform.position).normalized;

        //To actually move the enemy
        float step = enemy.SPEED * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, node.GetPosition(), step);
    }
}
