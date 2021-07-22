using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_PowerMoss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.2f, 0,0);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Destroy(gameObject);
        }
    }
}
