using System.Collections;
using System.Collections.Generic;  
using UnityEngine;

public class VirtualJoystick : MonoBehaviour
{
    
    public SpriteRenderer renderer;
    
    private float _horizontalAxis;
    public float horizontalAxis {
        get { return _horizontalAxis; }
    }
    
    private float _verticalAxis; 
    public float verticalAxis {
        get { return _verticalAxis; }
    }

    Vector2 touchPos;
    float horizontal;
    float vertical;
    
    Touch currentTouch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateAxisValues();
    }
    
    void CalculateAxisValues() {
        if(Input.touchCount > 0){
            currentTouch = Input.GetTouch(0);
        
            touchPos = currentTouch.position;
            
            horizontal = // calculate horizontal value
            vertical = // calculate vertical value
            
            _horizontalAxis = horizontal;
            _verticalAxis = vertical;
        }
    }

    public void HandleInput(Touch touch, TouchPhase phase) {
        CalculateAxisValues();
    }
}
