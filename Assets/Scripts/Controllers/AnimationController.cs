using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AnimationStates
{
    string isIdle;
    string isDead;
    string isGettingHit;
    string isAttacking;
    string isWalking;

    public string IsIdle
    {
        get
        {
            return isIdle;
        }

        set
        {
            isIdle = value;
        }
    }

    public string IsDead
    {
        get
        {
            return isDead;
        }

        set
        {
            isDead = value;
        }
    }

    public string IsGettingHit
    {
        get
        {
            return isGettingHit;
        }

        set
        {
            isGettingHit = value;
        }
    }

    public string IsAttacking
    {
        get
        {
            return isAttacking;
        }

        set
        {
            isAttacking = value;
        }
    }

    public string IsWalking
    {
        get
        {
            return isWalking;
        }

        set
        {
            isWalking = value;
        }
    }
    public AnimationStates(string isIdle = "isIdle", 
                           string isDead = "isDead",
                           string isGettingHit = "isGettingHit", 
                           string isAttacking = "isAttacking", 
                           string isWalking = "isWalking")
    {
        this.isIdle = isIdle;
        this.isDead = isDead;
        this.isGettingHit = isGettingHit;
        this.isAttacking = isAttacking;
        this.isWalking = isWalking;
    }
}
public class AnimationController : MonoBehaviour {
    private List<string> animationBools;
    private Animator anim;
    public  AnimationStates animationStates { protected set; get; }

    // Use this for initialization
    void Start () {
        animationStates = new AnimationStates("isIdle");
        animationBools = new List<string>();
        string[] animStates = { animationStates.IsIdle, animationStates.IsDead, animationStates.IsGettingHit, animationStates.IsAttacking, animationStates.IsWalking };
        animationBools.AddRange(animStates);
        anim = GetComponentInChildren<Animator>();
    }
	
   
    public string CurrentAnimation()
    {
        string currentAnimation = "";
        foreach (string item in animationBools)
        {
            if (anim.GetBool(item))
            {
                currentAnimation = item;
                break;
            }
        }
        return currentAnimation;
    }

    public void ChangeAnimationBool(string key = "")
    {
        foreach (string item in animationBools)
        {
            anim.SetBool(item, false);
        }
        if (key != "")
        {
            anim.SetBool(key, true);
        }
    }

    public float CurrentAnimationLength()
    {
        return anim.GetCurrentAnimatorStateInfo(0).length;
    }

    public bool IsThisAnimationPlaying(string animationLabel)
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName(animationLabel);
    }
}
