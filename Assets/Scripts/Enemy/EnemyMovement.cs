using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Enemy enemy;
    [SerializeField] private GameObject player;
    private List<GraphNode> pathToPlayer = new List<GraphNode>();
    private bool timerBool = true;

    public void Setup(Enemy enemy){
        this.enemy = enemy;
        pathToPlayer = enemy.graph.PathFinding(this.transform.position, player.transform.position);
    }

    public void UpdateMovement()
    {
        if (timerBool){
            Invoke("RecalculatePathFinding", 0.3f);
            timerBool = false;
        }
        
        if (pathToPlayer.Count == 0){
            return;
        }

        GoToPoint(pathToPlayer[pathToPlayer.Count-1]);
    }

    private void RecalculatePathFinding(){
        pathToPlayer = enemy.graph.RecalculatePathFinding(this.transform.position, player.transform.position);
        if (pathToPlayer != null)
        {
            if (HasEnemyReachedNode(pathToPlayer[pathToPlayer.Count-1], transform.position))
            {
                pathToPlayer.RemoveAt(pathToPlayer.Count-1);
            }
        }
        timerBool = true;
    }

    private bool HasEnemyReachedNode(GraphNode targetNode, Vector2 enemyPosition)
    {
        return (Vector3.Distance(targetNode.GetPosition(), transform.position) < 0.5f);
    }


    private void GoToPoint(GraphNode node)
    {
        //We check if enemy reached node to go to the next one, if so we remove it from the list
        if (HasEnemyReachedNode(node, transform.position))
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
