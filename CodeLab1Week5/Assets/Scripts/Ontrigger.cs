using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ontrigger : MonoBehaviour
{
    // Start is called before the first frame update
    
   
        // Start is called before the first frame update
        public bool ReachedPrize = false;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
       
            if (other.gameObject.CompareTag("Player"))
            {
                ReachedPrize = true;
               
            }
            else
            {
                ReachedPrize = false;
            }


        }
    
//    private void OnTriggerEnter2D(Collider2D other)
//    {
//       
//        if (other.gameObject.CompareTag("Player"))
//        {
//            if(playerScore < winningScore)
//            {
//                randomPos = new Vector2 (Random.Range(BoundsMin.x + transform.localScale.x,BoundsMax.x -transform.localScale.x),
//                    Random.Range(BoundsMin.y + transform.localScale.y,BoundsMax.y -transform.localScale.y));
//            
//                //new prize teleports to a position within the bounds of the Collider of WallBounds
//                transform.position = randomPos;
//                
//                //Players score 1 point as a team
//                PlayerScore++;
//               
//                //tried to spawn prize using the position of the four walls
//                // new Vector2(Random.Range(leftWall.position.x + leftWall.localScale.x,rightWall.position.x - rightWall.localScale.x),
//                // Random.Range(lowWall.position.y + lowWall.localScale.y,topWall.position.y - topWall.localScale.y));
//            }
//            else
//            {
//                Destroy(gameObject);
//            }
//        }
//        
//        //competitive version 
//        /*if (other.gameObject.name.Equals("Player1"))
//        {
//            
//            player1Score++;
//
//        }
//        if (other.gameObject.name.Equals("Player2"))
//        {
//           
//            player1Score++;
//
//        }*/
//    }
}
