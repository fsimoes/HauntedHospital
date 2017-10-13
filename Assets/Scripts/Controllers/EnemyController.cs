using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
    public float lookRadius = 10f;
    Transform target;
    static Animator anim;

    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(target.position, transform.position);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("creature1Spawn") || anim.GetCurrentAnimatorStateInfo(0).IsName("creature1roar"))
        {
            agent.velocity = Vector3.zero;
        }

        if (distance <= lookRadius){
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                FaceTargert();
                agent.velocity = Vector3.zero;
                anim.SetBool("isIdle", false);
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
            else if(agent.speed > 0)
            {
                anim.SetBool("isIdle", false);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isWalking", true);
            }else
            {
                anim.SetBool("isIdle", true);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isWalking", false);
            }
        }
	}

    void FaceTargert()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }
}
