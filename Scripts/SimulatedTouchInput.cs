using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulatedTouchInput : MonoBehaviour {

    public VirtualJoystick virtualJoystick;   

  void Update() {
  
    // Detect mouse down as touch start
    if(Input.GetMouseButtonDown(0)) {
      SimulateTouch(Input.mousePosition, TouchPhase.Began);
    }
    
    // Detect mouse held down as touch move
    while(Input.GetMouseButton(0)) {
      SimulateTouch(Input.mousePosition, TouchPhase.Moved);
    }
    
    // Detect mouse up as touch end
    if(Input.GetMouseButtonUp(0)) {
      SimulateTouch(Input.mousePosition, TouchPhase.Ended);
    }
  
  }

  void SimulateTouch(Vector2 position, TouchPhase phase) {
  
    // Create simulated touch
    Touch touch = new Touch();
    touch.fingerId = 0;
    touch.position = position;
    touch.phase = phase;

    // Pass simulated touch to joystick
    virtualJoystick.HandleInput(touch, phase);

  }
  
}
