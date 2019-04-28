using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour {

    [SerializeField]
    private float lookRadius = 10f;

    private Transform target;
    private NavMeshAgent agent;


	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        if (agent != null) {
           // print("got the agent");
            agent.Warp(transform.position);
        }
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius) {
            
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance) {
                // Perform "Attack"
                // Rotate to face player

                PlayerModel.Instance.UpdateHealth(-1);
                FaceTarget();
            }
        }
	}

    private void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookDirection = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, Time.deltaTime * 5);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
