using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour {
    AnimationController animationController;
    NavMeshAgent agent;
    float currentTime = 0;
    bool isPlayingDeathAnimation = false;
    public bool isAlive { set; get; }

    public Transform target;
    PlayerHealthScript playerHealth;

    public float damageInterval = 1;
    public int attackDamage;
    public float life = 100;
    public float lookRadius = 10f;

    bool playerInRange;

    Collider col;
    public NavMeshPath navMeshPath;

 
    // Use this for initialization
    void Start () {
        animationController = GetComponent<AnimationController>();
       
        target = target ? target : GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = target.GetComponent<PlayerHealthScript>();
        agent = GetComponent<NavMeshAgent>();
        isAlive = true;
        col = GetComponent<Collider>();
        navMeshPath = new NavMeshPath();
    }




    // Update is called once per frame
    void Update ()
    {
      
        currentTime += Time.deltaTime;
        float distance = Vector3.Distance(target.position, transform.position);
        if (animationController.CurrentAnimation() ==  animationController.animationStates.IsIdle 
            || !isAlive
            || animationController.IsThisAnimationPlaying("Spawn")
            || animationController.IsThisAnimationPlaying("Intro")
            || animationController.IsThisAnimationPlaying("GetHit"))
        {
            agent.velocity = Vector3.zero;
        } 

        if (distance <= lookRadius && isAlive)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance && currentTime > damageInterval && isAlive)
            {
                FaceTarget();
                agent.velocity = Vector3.zero;
                animationController.ChangeAnimationBool(animationController.animationStates.IsAttacking);
                Attack();         
            }
            else if (!CalculateNewPath())
            {
                animationController.ChangeAnimationBool(animationController.animationStates.IsIdle);
            }
            else if(agent.speed > 0)
            {
                animationController.ChangeAnimationBool(animationController.animationStates.IsWalking);
            }
            else 
            {
                animationController.ChangeAnimationBool(animationController.animationStates.IsIdle);
            }
        }
        if (animationController.IsThisAnimationPlaying("Die") && 
            animationController.CurrentAnimation() == animationController.animationStates.IsDead && 
            !isPlayingDeathAnimation)
        {
            animationController.ChangeAnimationBool();
            isPlayingDeathAnimation = true;
            Destroy(this.gameObject, animationController.CurrentAnimationLength() + 0.25f);
        }
        //if (currentTime > damageInterval && isAlive)
        //{
        //    damageInterval = currentTime + 2;
        //    TakeDamage(20);
        //}
    }

    void Attack()
    {
        currentTime = 0;
        if (playerHealth.curHealth > 0)
        {
            playerHealth.PlayerDamage(attackDamage);
        }
    }

    bool CalculateNewPath()
    {
        agent.CalculatePath(target.position, navMeshPath);
        if (navMeshPath.status != NavMeshPathStatus.PathComplete)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void FaceTarget()
    {
        if(CalculateNewPath())
        { 
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

    public void TakeDamage(float damage)
    {
        if (!isAlive)
        {
            return;
        }
        life -= damage;

        animationController.ChangeAnimationBool(animationController.animationStates.IsGettingHit);


        if (life <= 0 && isAlive)
        {
            col.enabled = false;
            isAlive = false;
            animationController.ChangeAnimationBool(animationController.animationStates.IsDead);

        }
    }

   

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }
}
