using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Ghost, Idamageable
{
    public static Skeleton instance;
    void Awake() {
        if(instance == null)
            instance = this;
    }
    public override void Start()
    {
        base.Start();
        health = 100;    }
    public int Health { get; set; }

    public void Damage(int damage)
    {
       Animations_Ghost.instance.Hit(animator);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != "Player" && other.tag != "ground"){
            Damage(1);
            health -= 20;
            Debug.Log(health + "current health gaint");
            if(health <=0){
                speed = 0f;
                Animations_Ghost.instance.Die(animator);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(DieTime());
                return;
            }
        }
        //Debug.Log("Damage");
    }

    IEnumerator DieTime(){
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
