using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRad = 10f;

    Transform target;
    NavMeshAgent agent;

    public int value = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRad){
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance){
                
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player"){
            FindObjectOfType<HealthManager>().HurtPlayer(value);
        }
    }
}