using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moss_Giant : Ghost, Idamageable
{
    public static Moss_Giant instance;
    void Awake() {
        if(instance == null)
            instance = this;
    }
    public GameObject player;
    public GameObject power;
    [System.Serializable]
    public class Moss_Gaint_Data{
        public int health;
    }
    [System.Serializable]
    public class List_Moss_Data {
        public Moss_Gaint_Data moss_gaint_data;
    }
    public List_Moss_Data data_moss = new List_Moss_Data();
    float posPlayer;
    public override void Start() {
        base.Start();
        TextAsset data = Resources.Load("data") as TextAsset;
        data_moss = JsonUtility.FromJson<List_Moss_Data>(data.text);
        Debug.Log(data_moss.moss_gaint_data.health + " Health Moss");
        health = data_moss.moss_gaint_data.health;
    }
    void FixedUpdate() {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if(distance > 15f){
            Animations_Ghost.instance.Idle(animator); 
        }
    }
    void CheckAttack(){
        posPlayer = transform.position.x - player.transform.position.x;
        float distance = Vector2.Distance(player.transform.position, transform.position);
        //Debug.Log(distance + "distance");
        if(distance < 5f){
            Animations_Ghost.instance.Attack(animator);
        }else{
            // Animations_Ghost.instance.Attack(animator);
            // speed=0;
            // StartCoroutine(HitTime());
            if(posPlayer < 0)
                Instantiate(power, new Vector3(transform.position.x, transform.position.y-2f, 0), Quaternion.Euler(0,0, 0f));
            else
                Instantiate(power, new Vector3(transform.position.x, transform.position.y-2f, 0), Quaternion.Euler(0,0, 180f));

        }
    }
    public int Health { get; set; }

    public void Damage(int damage)
    {
       Animations_Ghost.instance.Hit(animator);
       CheckAttack();
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

    IEnumerator HitTime(){
        yield return new WaitForSeconds(2.5f);
        speed = 0.05f;
    }
}
