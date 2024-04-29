using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // variables pour tirer les particules
    public float chrono = 3f;
    public float fireIntervale = 3f;
    public GameObject _particlesPreFabs;
    
    public float spawnRadius = 1f;
    void Start()
    {
       
        chrono += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        chrono += Time.deltaTime;
        if (chrono >= fireIntervale)
        {
            Vector2 spawnPostion = (Vector2) transform.position + Random.insideUnitCircle * spawnRadius;
            GameObject particles = Instantiate(_particlesPreFabs, spawnPostion, Quaternion.identity);
            particles.GetComponent<Rigidbody2D>().velocity = transform.right * 10f;
            chrono = 0f;
        }          
    }              
    
}  
