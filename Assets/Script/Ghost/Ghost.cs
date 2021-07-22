using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ghost : MonoBehaviour
{
    // Start is called before the first frame upd
    [HideInInspector]
    public Vector2 point_X, point_Y;
    public float pointX;
    [HideInInspector]
    public float speed = 0.05f;
    [HideInInspector]
    public int health;
    protected Animator animator;
    public virtual void Start()
    {
        point_X = transform.position;
        point_Y = transform.position + new Vector3(pointX,0f,0f);
        animator = GetComponentInChildren<Animator>();
        //Debug.Log(animator.name + "name");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement(){
        transform.Translate(speed,0f,0);
        if(transform.position.x >= point_Y.x){
            GetComponentInChildren<SpriteRenderer>().flipX = !GetComponentInChildren<SpriteRenderer>().flipX;
            speed = -speed;
        }
        if(transform.position.x <= point_X.x){
            GetComponentInChildren<SpriteRenderer>().flipX = !GetComponentInChildren<SpriteRenderer>().flipX;
            speed = -speed;
        }
    }
}
