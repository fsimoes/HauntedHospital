using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{
    AnimationController animationController;
    public Image HealthStatus;
    public Text HealthText;
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
        HealthText.text = curHealth.ToString();
        HealthStatus.fillAmount = ((float)curHealth / maxHealth);

        if (curHealth <= 0)
        {
            curHealth = 0;
            Death();
            Time.timeScale = 0.0f;
        }
    }

    public void Death()
    {
        IsDead = true;
        animationController.ChangeAnimationBool(animationController.animationStates.IsDead);

    }



}
