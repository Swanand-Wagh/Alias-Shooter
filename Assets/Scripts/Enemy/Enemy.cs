using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyController))]
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private NavMeshAgent pathfinder;
    private Transform player;

    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdateEnemyPath());
    }

    void Update()
    {
    }

    // Since pathfinding is expensive, we create a coroutine & call it every 1/4th second.
    IEnumerator UpdateEnemyPath()
    {
        float refreshRate = 0.25f;
        while (player != null)
        {
            pathfinder.SetDestination(new Vector3(player.position.x, 0, player.position.z));
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
