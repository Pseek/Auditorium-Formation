using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    [SerializeField] private CanvasGroup _myUIGroup;

    [SerializeField] private bool _fadeIn = false;
    [SerializeField] private bool _fadeOut = false;
    

    public void ShowUI()
    {
        _fadeIn = true;
    }

    public void HideUI() 
    { 
        _fadeOut = true; 
    }

    private void Update()
    {
        if (_fadeIn)
        {
            if (_myUIGroup.alpha < 1) 
            {
                _myUIGroup.alpha = Time.deltaTime;
                if(_myUIGroup.alpha >= 1)
                {
                    _fadeIn = false;
                   

                }
            }
        }

        if (_fadeOut)
        {
            if (_myUIGroup.alpha >= 0)
            {
                _myUIGroup.alpha = Time.deltaTime;
                if (_myUIGroup.alpha == 0)
                {
                    _fadeOut = false;
                }
            }
        }
    }
}
    
