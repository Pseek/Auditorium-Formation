using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MouseManager : MonoBehaviour
{
    //variable pour le raycast

    private Ray _ray;

    //pour afficher les images

    public Texture2D centerIcon;
    public Texture2D outterIcon;
    
    // variables pour les buttons de la souris

    public bool _isClicked;

    //variables pour deplacer ou modifier l'objet

    private GameObject _objectToMove = null;
    private CircleShape _objectToResize = null;
    private AreaEffector2D _objectToEffector = null;

    public Vector3 _worldPosition;

    // pour le radius du cercle
    public float _minRadius = 1f;
    public float _maxRadius = 10f;
    public float radiusRatio = 4f;
    public float magnitudeMinimum = 4f;

    private bool _isInterracting = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        
        //pour déplacer l'objet selectionner
        if (_isClicked && _objectToMove != null)
        {
            _objectToMove.transform.position = _worldPosition;
            _isInterracting = true;
        }
        if (_isClicked && _objectToResize != null)
        {
            float radius = Vector2.Distance(_worldPosition, _objectToResize.transform.position);
            _objectToResize.Radius = Mathf.Clamp(radius, _minRadius, _maxRadius );
            _objectToEffector.forceMagnitude = magnitudeMinimum - (radiusRatio) + radiusRatio * _objectToResize.Radius;
            _isInterracting = true;
        }
        if (!_isClicked)
        {
            _objectToMove = null;
            _objectToResize = null;
            _isInterracting = false;
        }
    }
    // pour dectecter les movement de la souris 
    public void PointerMove(InputAction.CallbackContext context)
    {
        //pour indiquer la position du pointer
        

        Vector2 pointerPosition = context.ReadValue<Vector2>();
        if (pointerPosition == null || Camera.main == null)
        {
            return;
        }
        
        _ray = Camera.main.ScreenPointToRay(pointerPosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(_ray);

        //pour indiquer la position du pointer et la convertir dans le world Unity

        _worldPosition = Camera.main.ScreenToWorldPoint(pointerPosition);
        _worldPosition.z = 0; 

        //pour indiquer s'il est sur un objet ou pas

        if ( hit.collider != null)
        {
            if (_isInterracting)
            {
                return;
            }
            // pour l'indiquer s'il est sur la flèches 

            if (hit.collider.CompareTag("Fleche"))
            {
                Cursor.SetCursor(centerIcon,new Vector2 (256,256),CursorMode.Auto);
                _objectToMove =  hit.collider.transform.parent.gameObject;
            }
            // pour l'indiquer s'il est sur le cercle

            else if( hit.collider.CompareTag("Cercle"))
            {
                Cursor.SetCursor(outterIcon, new Vector2(256, 256), CursorMode.Auto);
                _objectToResize = hit.collider.GetComponent<CircleShape>();
                _objectToEffector = hit.collider.GetComponent<AreaEffector2D>();
            }
        }
        // pour l'indiquer s'il est sur du vide

        else
        {
            Cursor.SetCursor(null,Vector2.zero, CursorMode.Auto);
            
        }
            
    }
    // pour dessiner le trait de raycast

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay( _ray.origin, _ray.direction * 1000f);
    }
    // pour les buttons du pointer

     public void PointerClick (InputAction.CallbackContext context)
    {


        switch (context.phase)
        {
            case InputActionPhase.Started:
                //Action qui débute
                break;
            case InputActionPhase.Performed:
                //Action qui est effectuée
                //Le click est actif
                _isClicked = true;
                break;
            case InputActionPhase.Canceled:
                //Action qui est annulée
                //Le click est inactif
                _isClicked = false;
                break;
            default:
                break;
        }
    }
}
