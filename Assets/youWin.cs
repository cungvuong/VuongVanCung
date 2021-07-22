using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class youWin : MonoBehaviour
{
    public GameObject win;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        win.SetActive(true);
        return;
    }
}
