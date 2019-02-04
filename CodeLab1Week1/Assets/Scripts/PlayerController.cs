using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode DownKey;
    public KeyCode LeftKey;
    public KeyCode RightKey;
    private Rigidbody2D rb;
    public float forceAmount = 10f;
    private float player1Score = 0;
    private float player2Score = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       Vector2 newForce = new Vector2(0,0);// the force we will add to player
        if (Input.GetKey(upKey))
        {
            newForce.y += forceAmount;
        }
       else if (Input.GetKey(DownKey))
        {
            newForce.y -= forceAmount;
        }
       else if (Input.GetKey(LeftKey))
        {
            newForce.x -=forceAmount;
        }
        else if (Input.GetKey(RightKey))
        {
            newForce.x += forceAmount;
        }
        else
        {
            newForce.x = 0;
            newForce.y = 0;
        }

        rb.AddForce(newForce);
    }
}
