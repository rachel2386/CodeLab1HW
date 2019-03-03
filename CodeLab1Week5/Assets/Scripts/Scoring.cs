using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    private Collider2D _myCollider;
    private Text _playerScoreText;
    private Text _highScoreText;
    private Text _timeText;
    
    private int playerScore;
    private const string PLAYER_PREF_TIMERECORD = "recordT";
    private float defaultRecord = 300f;

    private bool newRecord = false;
    public int PlayerScore
    {
        get => playerScore;
        set => playerScore = value;
    }

    private float timeSpent = 0;

    private float TimeSpent
    {
        get => timeSpent;
        set
        {
            timeSpent = value;
            _timeText.text = "Time: " + System.Math.Round(timeSpent, 2) + "s";
            

        } 
    }

    private float recordT;

    private float RecordTime
    {
         get => recordT;
       
        set
        {
           
                 if (value > recordT)
                {
                    recordT = value;
                    
                    PlayerPrefs.SetFloat(PLAYER_PREF_TIMERECORD,recordT);
                    PlayerPrefs.Save();
                
                }
          
        }
    }


    private Collider2D WallBounds;
    private Vector2 BoundsMin;
    private Vector2 BoundsMax;
    
    public Vector2 randomPos;

    public int winningScore;
    
    
    
    void Start()
    {
        _myCollider = GetComponent<Collider2D>();
        //Get the min and max bounds of the spawnable space 
        WallBounds = GameObject.Find("WallBounds").GetComponent<Collider2D>();
        _playerScoreText = GameObject.Find("1").GetComponent<Text>();
        _highScoreText = GameObject.Find("Record").GetComponent<Text>();
        _timeText = GameObject.Find("timeSpent").GetComponent<Text>();
        BoundsMin = WallBounds.bounds.min;
        BoundsMax = WallBounds.bounds.max;
        
       
        
        float playerpref = PlayerPrefs.GetFloat(PLAYER_PREF_TIMERECORD, defaultRecord);
        print("playerPrefFile" + playerpref);
        _highScoreText.text = "Record: " + System.Math.Round(playerpref, 2) + "s";  
        

    }

    public void ResetPlayerRef()
    {
        PlayerPrefs.SetFloat(PLAYER_PREF_TIMERECORD, defaultRecord);
        print("Reset PlayerPref to " + PlayerPrefs.GetFloat(PLAYER_PREF_TIMERECORD));
    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
       
           if (other.gameObject.CompareTag("Player"))
           {
            if(playerScore < winningScore)
               {
                randomPos = new Vector2 (Random.Range(BoundsMin.x + transform.localScale.x,BoundsMax.x -transform.localScale.x),
                                    Random.Range(BoundsMin.y + transform.localScale.y,BoundsMax.y -transform.localScale.y));
            
                //new prize teleports to a position within the bounds of the Collider of WallBounds
                transform.position = randomPos;
                
                //Players score 1 point as a team
                PlayerScore++;
               
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
        if (playerScore < winningScore)
        { _playerScoreText.text = "" + playerScore;}
        else
        { _playerScoreText.text = "VICTORY";}
        
        //Player2Text.text = "" + player2Score;
    }

    private void Update()
    {
        ShowText();
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        
        if (currentScene == 1)
        {
            if (playerScore < winningScore)
            {
                TimeSpent += Time.deltaTime;
            }
            else
            {
         
                if ((float)System.Math.Round(TimeSpent, 2) < PlayerPrefs.GetFloat(PLAYER_PREF_TIMERECORD))
                    {

                       
                        newRecord = true;
                       
                    }

                if (newRecord)
                {
                    RecordTime = (float)System.Math.Round(timeSpent, 2);
                    
                }
            }

        }

        


    }

  
}
