using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
    public float lookRadius = 10f;
    public Transform target;
    private Animator anim;
    private NavMeshAgent agent;
    int life = 100;
    bool isAlive = true;
    public float damageInterval = 5;
    bool isPlayingDeathAnimation = false;
    float currentTime = 0;

    // Use this for initialization
    void Start () {
        target = target ? target:GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        float distance = Vector3.Distance(target.position, transform.position);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("creature1Spawn") || anim.GetCurrentAnimatorStateInfo(0).IsName("creature1roar") || !isAlive
            || anim.GetCurrentAnimatorStateInfo(0).IsName("creature1GetHit") || anim.GetBool("isGettingHit"))
        {
            agent.velocity = Vector3.zero;
         
        } 
        

        if (distance <= lookRadius && isAlive){
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                agent.velocity = Vector3.zero;
                anim.SetBool("isIdle", false);
                anim.SetBool("isDead", false);
                anim.SetBool("isGettingHit", false);
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
                
            }
            else if(agent.speed > 0)
            {
                anim.SetBool("isIdle", false);
                anim.SetBool("isDead", false);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isGettingHit", false);
                anim.SetBool("isWalking", true);
            }
            else
            {
                anim.SetBool("isIdle", true);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isDead", false);
                anim.SetBool("isWalking", false);
                anim.SetBool("isGettingHit", false);

            }
        }

        if (currentTime > damageInterval && isAlive)
        {
            damageInterval = currentTime + 2;
            TakeDamage(30);
        }
         
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("creature1Die") && !isPlayingDeathAnimation) 
        {
            anim.SetBool("isDead", false);
            isPlayingDeathAnimation = true;
            Destroy(this.gameObject, (anim.GetCurrentAnimatorStateInfo(0).length) + 0.25f);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void TakeDamage(int damage)
    {
        life -= damage;
        anim.SetBool("isIdle", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isWalking", false);
        anim.SetBool("isDead", false);
        anim.SetBool("isGettingHit", true);

        if (life <= 0 && isAlive)
        {
            isAlive = false;
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isGettingHit", false);
            anim.SetBool("isDead", true);
        }
    }

  

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }
}
