using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    Transform playerTransform;
    NavMeshAgent nav;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        nav = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        nav.SetDestination(playerTransform.position);
        transform.LookAt(playerTransform);
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
    }
}
