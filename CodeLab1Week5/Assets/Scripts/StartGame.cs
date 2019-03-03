using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource[] _myAudioList;
    private AudioSource _casual;
    private AudioSource _ordinary;
    private AudioSource _action;
    private GameObject _startButton;
    public static StartGame Instance;
    private bool _moodSelected;


//duplicated GameManager since the GM Instance stored in OnClick() script in button changes
//as GM becomes DontDestroyOnload.
//The stored instance should be assigned through script. Dragging into inspector slot does not work
//make AudioManager DontDestroyOnload instead so music does not break when scenes swap. 

    private void Start()
    {
        _startButton = GameObject.Find("StartButton");
        _moodSelected = false;
        if (_startButton != null)
            _startButton.SetActive(false);

        _myAudioList = GameObject.Find("AudioManager").GetComponents<AudioSource>();
        _casual = _myAudioList[0];
        _ordinary = _myAudioList[1];
        _action = _myAudioList[2];
    }



    private void Update()
    {
        if (_startButton != null)
        {
            
            if(_moodSelected)
                EnableStart();
        }
   
    }

    public void PlayCasual()
    {
       
        _moodSelected = true; 
   
       
        if (!_casual.isPlaying)
        {

            
            _casual.Play();
            _ordinary.Stop();
            _action.Stop();
           
          
        }
    }
    public void PlayOrdinary()
    {
      
        _moodSelected = true;
        if (!_ordinary.isPlaying)
        {
            _ordinary.Play();
            _casual.Stop();
            _action.Stop();
            
        }
           
          
        
    }
    public void PlayAction()
    {
      
        _moodSelected = true;
       if (!_action.isPlaying)
        {
            _action.Play();
            _ordinary.Stop();
            _casual.Stop();
           
     
        }
    }

    private void EnableStart()
    {

        if (_moodSelected)
        {
           
               _startButton.SetActive(true);
        }

    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
        
    }

   public void GoToMenu()
   {
      
        SceneManager.LoadScene(0);
     
    }

}
