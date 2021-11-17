using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Enemy enemy;
    private List<GraphNode> pathToTarget = new List<GraphNode>();
    private bool timerBool = true;
    private bool waiting = false;
    private bool pathToSpawnCalculated = false;
    private Vector2 randomPoint;
    private float WAIT_TIME = 3f;
    private float TIME_TO_RECALCULATE_PATH = 0.3f;

    public void Setup(Enemy enemy){
        this.enemy = enemy;
        randomPoint = enemy.spawnPoint;
        //pathToPlayer = enemy.graph.PathFinding(this.transform.position, enemy.player.transform.position);
    }

    public void Attack()
    {
        pathToSpawnCalculated = false;
        if (timerBool){
            Invoke("RecalculatePathFinding", TIME_TO_RECALCULATE_PATH);
            timerBool = false;
        }
        
        if (pathToTarget == null || pathToTarget.Count == 0){
            return;
        }

        GoToNode(pathToTarget[pathToTarget.Count-1]);
    }

    private void RecalculatePathFinding(){
        pathToTarget = enemy.graph.RecalculatePathFinding(this.transform.position, enemy.player.transform.position);
        if (pathToTarget != null)
        {
            if (HasEnemyReachedPoint(pathToTarget[pathToTarget.Count-1].GetPosition()))
            {
                pathToTarget.RemoveAt(pathToTarget.Count-1);
            }
        }
        timerBool = true;
    }

    private bool HasEnemyReachedPoint(Vector2 point)
    {
        return (Vector3.Distance(point, transform.position) < 0.5f);
    }


    private void GoToNode(GraphNode node)
    {
        //We check if enemy reached node to go to the next one, if so we remove it from the list
        if (HasEnemyReachedPoint(node.GetPosition()))
        {
            pathToTarget.RemoveAt(pathToTarget.Count-1);
            return;
        }

        //To actually move the enemy
        GoToPoint(node.GetPosition());
    }

    public void Roam()
    {
        pathToSpawnCalculated = false;
        if (HasEnemyReachedPoint(randomPoint) && !waiting)
        {
            waiting = true;
            StartCoroutine(WaitBeforeMoving(WAIT_TIME));
        }

        GoToPoint(randomPoint);
    }

    IEnumerator WaitBeforeMoving(float time)
    {
        yield return new WaitForSeconds(time);
        randomPoint = ((Vector2) enemy.spawnPoint) + Random.insideUnitCircle * enemy.RADIUS_OF_SPAWN;
        
        //If the randomPoint is though a wall, the randomPoint will be change to be the wall
        Vector2 direction = randomPoint - (Vector2)transform.position;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, direction, Vector2.Distance(randomPoint, transform.position));
        if (raycastHit2D.collider != null)
        {
            randomPoint = raycastHit2D.point;
        }
        waiting = false;
    }

    private void GoToPoint(Vector2 point)
    {
        //A vector for the animations
        enemy.direction = (point - (Vector2)transform.position).normalized;

        float step = enemy.SPEED * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, point, step);
    }

    public void Return(){
        if (!pathToSpawnCalculated || pathToTarget.Count == 0)
        {
            pathToTarget = enemy.graph.RecalculatePathFinding(this.transform.position, enemy.spawnPoint);
            pathToSpawnCalculated = true;
        }

        GoToNode(pathToTarget[pathToTarget.Count-1]);
    }
}
