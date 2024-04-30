using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MouseManager : MonoBehaviour
{
    private Ray _ray;
    public Texture2D centerIcon;
    public Texture2D outterIcon;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void PointerMove(InputAction.CallbackContext context)
    {
        Vector2 pointerPosition = context.ReadValue<Vector2>();
        _ray = Camera.main.ScreenPointToRay(pointerPosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(_ray);

        if ( hit.collider != null)
        {
            if (hit.collider.CompareTag("Fleche"))
            {
                Cursor.SetCursor(centerIcon,new Vector2 (256,256),CursorMode.Auto);
            }
            else if( hit.collider.CompareTag("Cercle"))
            {
                Cursor.SetCursor(outterIcon, new Vector2(256, 256), CursorMode.Auto);
            }
        }
        else
        {
            Cursor.SetCursor(null,Vector2.zero, CursorMode.Auto);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay( _ray.origin, _ray.direction * 1000f);
    }
     public void PointerClick (InputAction.CallbackContext context)
    {
        
    }
}
