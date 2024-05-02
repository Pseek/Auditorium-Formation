using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Timescale : MonoBehaviour
{        
   public bool isTimeScaleZero = false;    
    void Start()
    {
        if (isTimeScaleZero == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        
    }
    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }

}
