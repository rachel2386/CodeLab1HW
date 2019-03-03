using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour
{

    
    private Vector2 prizePos;
    private GameObject[] PrizeArray;
    private int PrizeNum = 0;
    private Scoring scoringScript;
    void Start()
    {
        scoringScript = GameObject.FindGameObjectWithTag("ScriptHolder").GetComponent<Scoring>();
        print("Debug mode: r to reset enabled");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (scoringScript.PlayerScore >= scoringScript.winningScore)
        {
            PrizeArray = GameObject.FindGameObjectsWithTag("Respawn"); 
            PrizeNum = PrizeArray.Length;
            
           
            if (PrizeNum < 80)
            {
                SpawnBanana();
            }
            else
            {
                if(Input.GetKeyDown("r"))
                    SceneManager.LoadScene(1);
            }
        }
        
        if(Input.GetKeyDown("r"))
            SceneManager.LoadScene(1);
        

        
    }
    
    void SpawnBanana()
    {
        
        GameObject newPrize = Instantiate(Resources.Load("Prefab/Prize")) as GameObject;
        Rigidbody2D PrizeRB = newPrize.GetComponent<Rigidbody2D>();
        Vector2 randomPos = new Vector2(Random.Range(-7.60f, 7.60f),5.2f);
        newPrize.transform.position = randomPos;  
        PrizeRB.gravityScale = 1;
        newPrize.GetComponent<Scoring>().PlayerScore = scoringScript.winningScore;


    }
}
