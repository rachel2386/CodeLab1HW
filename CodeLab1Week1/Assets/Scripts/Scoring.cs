using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    private Collider2D myCollider;

    public float player1Score;
    private float player2Score = 0;
    
    private Text Player1Text;
   // public Text Player2Text;

    private Collider2D WallBounds;
    private Vector2 BoundsMin;
    private Vector2 BoundsMax;
    
    public Vector2 randomPos;

    public float winningScore;
    //public Transform leftWall;
   // public Transform rightWall;
    //public Transform topWall;
   // public Transform lowWall;
    
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        //Get the min and max bounds of the spawnable space 
        WallBounds = GameObject.Find("WallBounds").GetComponent<Collider2D>();
        Player1Text = GameObject.Find("1").GetComponent<Text>();
        BoundsMin = WallBounds.bounds.min;
        BoundsMax = WallBounds.bounds.max;
        
    }
    
    

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
       
           if (other.gameObject.CompareTag("Player"))
           {
            if(player1Score < winningScore)
               {
                randomPos = new Vector2 (Random.Range(BoundsMin.x + transform.localScale.x,BoundsMax.x -transform.localScale.x),
                                    Random.Range(BoundsMin.y + transform.localScale.y,BoundsMax.y -transform.localScale.y));
            
                //new prize teleports to a position within the bounds of the Collider of WallBounds
                transform.position = randomPos;
                
                //Players score 1 point as a team
                player1Score++;
               
                //tried to spawn prize using the position of the four walls
                // new Vector2(Random.Range(leftWall.position.x + leftWall.localScale.x,rightWall.position.x - rightWall.localScale.x),
                // Random.Range(lowWall.position.y + lowWall.localScale.y,topWall.position.y - topWall.localScale.y));
                }
               else
               {
                   Destroy(gameObject);
               }
           }
        
        //competitive version 
        /*if (other.gameObject.name.Equals("Player1"))
        {
            
            player1Score++;

        }
        if (other.gameObject.name.Equals("Player2"))
        {
           
            player1Score++;

        }*/
    }
    
    private void ShowText()
    {
        //show Score Text
        if (player1Score < winningScore)
        { Player1Text.text = "" + player1Score;}
        else
        { Player1Text.text = "VICTORY";}
        
        //Player2Text.text = "" + player2Score;
    }

    private void Update()
    {
        ShowText();
    }

  
}
