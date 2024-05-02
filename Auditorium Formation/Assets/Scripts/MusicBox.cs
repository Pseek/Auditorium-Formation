using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    //
    public AudioSource _audioSoucre;
    public Color _onColor;
    public Color _offColor;
    public SpriteRenderer[] _bars;

    public float volumeDecay = 0.02f;
    public float volumeIncrement = 0.1f;
    private float _chrono = 0f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _chrono += Time.deltaTime;
        _chrono = Mathf.Clamp(_chrono, 0f, 2f);
       
        // on utilise une boucle pour modifier le volume avec un visuel 
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
        // oublie de pas de mettre les op -= ou += pour modifier des valeurs plus de 1
        if (_chrono >= 1f)
        {
            _audioSoucre.volume -= volumeDecay * Time.deltaTime;
        }
        
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Particles"))
        {
            _audioSoucre.volume += volumeIncrement;
            _chrono = 0f;
        }
    }





}

