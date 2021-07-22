using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations_Ghost : MonoBehaviour
{
    public static Animations_Ghost instance;

    void Awake() {
        if(instance == null){
            instance = this;
        }
    }
    public void Idle(Animator ani){
        ani.SetBool("Attack", false);
    }

    public void Hit(Animator ani){
        ani.SetTrigger("Hit");
    }

    public void Attack(Animator ani){
        ani.SetBool("Attack", true);
    }

    public void Die(Animator ani){
        ani.SetTrigger("Die");
    }
}
