using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    public UnityEvent EndPanel = new UnityEvent();
    public GameObject[] boxMusic;
    public float _timer = 0f;
    private bool _isMusicMax = false;
    private int _nbrMusicBox = 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        CheckWin();
        if (_isMusicMax)
        {
            _timer += Time.deltaTime;
            if(_timer >= 2f)
            {
                EndPanel.Invoke();
            }

        }
        else
        {
            _timer = 0f;
        }
    }
    public void CheckWin()
    {
        _nbrMusicBox = 0;
        for (int i = 0; i < boxMusic.Length; i++) 
        {
            
            if (boxMusic[i].GetComponent<AudioSource>().volume >= 1)
            {
                _nbrMusicBox++;

            }

        } 
        if(_nbrMusicBox == boxMusic.Length) 
        {
            _isMusicMax=true;
        }
        else
        {
            _isMusicMax=false;
        }

    }
       
}            
            
        
    

