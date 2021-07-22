using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Idamageable
{
    public static Player instance;
    public GameObject healthBar;
    public GameObject playAgain;
    [HideInInspector]
    public bool isDead;
    float jumpForce = 13.0f;
    void Awake() {
        if(instance == null){
            instance = this;
        }
    }
    float speed = 10f;
    [HideInInspector]
    public int health_Current;
    int health_Max;
    float initHealth;
    [HideInInspector]
    public float move;
    float move_key;
    Rigidbody2D _rigid_player;
    public GameObject button_Awake;
    [System.Serializable]
    public class player_data {
        public int health;
    }
    [System.Serializable]
    public class List_Player {
        public player_data player_data;
    }
    public int Health { get; set; }

    List_Player player_data_list = new List_Player();
    void Start()
    {
        initHealth = healthBar.transform.localScale.x;
        TextAsset data = Resources.Load("data") as TextAsset;
        player_data_list = JsonUtility.FromJson<List_Player>(data.text);
        Debug.Log(player_data_list.player_data.health + " Health");
        health_Current = player_data_list.player_data.health;
        health_Max = player_data_list.player_data.health;

        _rigid_player = GetComponent<Rigidbody2D>();
        button_Awake.SetActive(true);
        playAgain.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead){
            Movement();
            Movement_Key();
        }
    }

    void Movement(){
        transform.Translate(new Vector3(move * speed * Time.deltaTime, 0,0));
    }

    void Movement_Key(){
        move_key = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(move_key * speed * Time.deltaTime, 0,0));
    }
    public void Jump(){
        bool grounded = CheckGround();
        if(grounded){
            _rigid_player.velocity = new Vector2(_rigid_player.velocity.x, jumpForce);
        }
        grounded = false;
        //Debug.Log(CheckGround());
    }
    bool CheckGround(){
        RaycastHit2D hitInfo;
        hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.515f, 1 << 8);
        //Debug.DrawRay(transform.position, Vector2.down, Color.green,3f);
        if(hitInfo.collider != null){
            return true;
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        //player_Animation.instance.Hit();
        //health_Current -= 10;
        Damage(5);
        healthBar.transform.localScale = new Vector3(initHealth*((float)health_Current/health_Max),0.5f,1f);
        if(healthBar.transform.localScale.x <= 0){
            healthBar.transform.localScale = Vector3.zero;
            player_Animation.instance.Die();
            isDead = true;
            return;
        }
    }

    public void Damage(int damage)
    {
        player_Animation.instance.Hit();
        health_Current -= damage;
        healthBar.transform.localScale = new Vector3(initHealth*((float)health_Current/health_Max),0.5f,1f);
        if(healthBar.transform.localScale.x <= 0){
            healthBar.transform.localScale = Vector3.zero;
            player_Animation.instance.Die();
            isDead = true;
            playAgain.SetActive(true);
            return;
        }
    }
}
