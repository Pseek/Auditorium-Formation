using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    public AudioSource _audioSoucre;
    public Color _onColor;
    public Color _offColor;
    public SpriteRenderer[] _bars;
    public float volumeDecay = 0.02f;
    public float volumeIncrement = 0.1f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _bars.Length; i++)
        {
            float seuil = (float)i / _bars.Length;
            if (_audioSoucre.volume > seuil )
            {
                _bars[i].color = _onColor;
            }
            else
            {
                _bars[i].color = _offColor;
            }

        }
        
        _audioSoucre.volume -= volumeDecay * Time.deltaTime;

        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Particles"))
        {
            _audioSoucre.volume += volumeIncrement;
        }
    }





}

