using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lead_Arrows : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        Transform_Arrows();
    }

    void Transform_Arrows(){
        if(!Arraw_key.instance.check_Direction){
            gameObject.transform.GetComponentInChildren<SpriteRenderer>().flipX = false;
            transform.position += new Vector3(0.6f, 0f, 0f);
        }
        else{
            gameObject.transform.GetComponentInChildren<SpriteRenderer>().flipX = true;
            transform.position += new Vector3(-0.6f, 0f, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != "Player"){
            Destroy(gameObject);
        }
    }
}
