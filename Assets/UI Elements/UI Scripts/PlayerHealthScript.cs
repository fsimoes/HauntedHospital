using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{
    AnimationController animationController;
    public Image HealthStatus;
    public int maxHealth = 100;
    public int curHealth = 0;

    public bool IsDead;
    bool isattacked;

    void Awake()
    {

        animationController = GetComponent<AnimationController>();
        curHealth = maxHealth;
                
    }



    public void PlayerDamage(int attackDamage)
    {
        curHealth -= attackDamage;
        
        HealthStatus.fillAmount =  ((float)curHealth / (float)maxHealth);

        if (curHealth <= 0 )
        {
            curHealth = 0;
            Death();
        }
    }

    public void Death()
    {
        animationController.ChangeAnimationBool(animationController.animationStates.IsDead);




    }

    

}
