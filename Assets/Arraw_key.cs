using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arraw_key : MonoBehaviour
{
    // Start is called before the first frame update
    public static Arraw_key instance;
    void Awake() {
        if(instance == null){
            instance = this;
        }
    }
    public SpriteRenderer sprite_Player;
    [HideInInspector]
    public bool check_Direction;
    public GameObject player;
    public GameObject pointSave1;
    public GameObject pointSave0;


    bool can_Shot = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump(){
        player_Animation.instance.Jump();
        Player.instance.Jump();
    }

    public void Left(){
        Player.instance.move = -1f;
        sprite_Player.flipX = true;
        player_Animation.instance.Walk();
    }

    public void Right(){
        player_Animation.instance.Walk();
        Player.instance.move = 1f;
        sprite_Player.flipX = false;
    }

    public void Idle(){
        player_Animation.instance.Idle();
        Player.instance.move = 0f;
    }
    public void Attack(){
        //StartCoroutine(waitBows());
        check_Direction = sprite_Player.flipX;
        //Debug.Log(check_Direction + "Check");
        if(can_Shot){
            player_Animation.instance.Attack();
            can_Shot = false;
            StartCoroutine(CanShot());
        }

    }
    public void Thrust(){
        //StartCoroutine(waitBows());
        check_Direction = sprite_Player.flipX;
        //Debug.Log(check_Direction + "Check");
        if(can_Shot){
            player_Animation.instance.Thrust();
            can_Shot = false;
            StartCoroutine(CanShot());
        }

    }
    public void PlayAgain(){
        SceneManager.LoadScene(0);
        //player.gameObject.GetComponent<Player>().Damage(-100);
        //player.gameObject.GetComponent<Player>().isDead = false;
        //player.gameObject.GetComponent<Animator>().SetBool("Save", true);
        // if(player.transform.position.x > pointSave1.transform.position.x)
        //     player.transform.position = pointSave1.transform.position;
        // else{
        //     player.transform.position = pointSave0.transform.position;
        // }
    }
    // IEnumerator waitBows(){
    // }

    IEnumerator CanShot(){
        yield return new WaitForSeconds(0.9f);
        can_Shot = true;
    }
}
