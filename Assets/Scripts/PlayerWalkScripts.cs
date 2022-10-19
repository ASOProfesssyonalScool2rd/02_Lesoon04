using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkScripts : MonoBehaviour
{
    private float WalkSpeed = 0.7f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(false)return; //←これでUpdateから先をKill(false)にすると解除
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0,0,WalkSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-WalkSpeed,0,0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(WalkSpeed,0,0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0,0,-WalkSpeed);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0,WalkSpeed,0);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0,-WalkSpeed,0);
        }
        
    }
}
