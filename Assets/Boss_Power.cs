using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Power : MonoBehaviour
{
    // Start is called before the first frame update
    bool fire = true;
    public GameObject arrmo;
    int j =0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fire){
            j+=10;
            if(j>100)
                j=0;
            for(int i=0; i<18; i++){
                Instantiate(arrmo, transform.position, Quaternion.Euler(0,0, 20 * i + j));
            }
            StartCoroutine(Fire_Boss());
        }
    }

    IEnumerator Fire_Boss(){
        fire = false;
        yield return new WaitForSeconds(2f);
        fire = true;
    }
}
