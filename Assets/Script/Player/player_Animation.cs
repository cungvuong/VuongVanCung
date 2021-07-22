using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Animation : MonoBehaviour
{
    public static player_Animation instance;
    void Awake() {
        if(instance == null){
            instance = this;
        }
    }
    Animator _ani;
    public GameObject arrows;
    void Start()
    {
        _ani = GetComponent<Animator>();
    }

    public void Walk(){
        _ani.SetBool("Walk", true);
    }
    public void Idle(){
        _ani.SetBool("Walk", false);
        _ani.SetBool("Bows", false);
    }
    public void Attack(){
        _ani.SetTrigger("Bows");
    }
    public void Jump(){
        _ani.SetTrigger("Jump");
    }
    public void Hit(){
        _ani.SetTrigger("Hit");
    }
    public void Die(){
        _ani.SetTrigger("Die");
    }
    public void Thrust(){
        _ani.SetTrigger("Thrust");

    }
    public void Fire(){
        Instantiate(arrows, transform.position + new Vector3(0.07f, -0.07f,0f), Quaternion.identity);
    }
}
