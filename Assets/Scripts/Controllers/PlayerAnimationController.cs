using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : AnimationController {

    Animator animator;
    PlayerController player;
    WeaponController weapon;
    bool isMoving;
    // Use this for initialization
    void Awake() {
        animator = GetComponentInChildren<Animator>();
        player = GetComponent<PlayerController>();
        weapon = GetComponentInChildren<WeaponController>();
    }
	
	// Update is called once per frame
	 void Update () {
        base.Update();
        if (player.v == 0 && player.h == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        animator.SetFloat("Vertical", player.v);
        animator.SetFloat("Horizontal", player.h);
        animator.SetBool("isShooting", weapon.IsShooting);
        animator.SetBool("isMoving", isMoving);
    }
    public float Reload()
    {
        animator.SetBool("IsReloading", true);
        AnimatorClipInfo[] animations = animator.GetCurrentAnimatorClipInfo(0);
        AnimationClip clip = animations[0].clip;
        //TODO make this dinamically
        float clipLength = 3.3f;//clip.length;
        ChangeAnimationBooleanWithTime(currentTime + clipLength, "IsReloading", false);
       
        return clipLength;
    }
    
}
