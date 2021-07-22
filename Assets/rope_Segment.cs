using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope_Segment : MonoBehaviour
{
    public GameObject connectedAbove, connnectedBelow;
    // Start is called before the first frame update
    void Start()
    {
        connectedAbove = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        rope_Segment aboveSegment = connectedAbove.GetComponent<rope_Segment>();
        if(aboveSegment != null){
            aboveSegment.connnectedBelow = gameObject;
            float spriteBottom = connectedAbove.GetComponent<SpriteRenderer>().bounds.size.y;
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, spriteBottom*(-0.5f));
        }else{
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
