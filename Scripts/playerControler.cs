using System.Collections;
using System.Collections.Generic;  
using UnityEngine;

public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D rigidbody2D;
        public SpriteRenderer playerSprite;
        Transform spriteTransform;

        private string horizontalTag;
        private string verticalTag;

        public float speed = 5f;

        public VirtualJoystick virtualJoystick;

        private Vector2 movement;

        private float lastHAxis;
        private float lastVAxis;


        public PlayerController(Rigidbody2D rigidbody) 

        {
            this.rigidbody2D = rigidbody;
        }

        private void Awake()
        {
            spriteTransform = playerSprite.transform;
            rigidbody2D = GetComponent<Rigidbody2D>();
            horizontalTag = "Horizontal";
            verticalTag = "Vertical";
        }

        private Vector2 CalculateMovement()
        {
            float hAxis = Input.GetAxis(horizontalTag);
            if (hAxis < -1 || hAxis > 1) hAxis = 0;
            
            float vAxis = Input.GetAxis(verticalTag);
            if (vAxis < -1 || vAxis > 1) vAxis = 0;

            if (hAxis == 0) {
                hAxis = lastHAxis; 
            }
            if (vAxis == 0) {
                vAxis = lastVAxis;
            }

            movement = new Vector2(hAxis, vAxis);

            return movement;
        }

        private void Update()
        {
            movement = CalculateMovement();

            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90f;
            spriteTransform.rotation = Quaternion.Euler(0f, 0f, angle);
            lastHAxis = movement.x;
            lastVAxis = movement.y;
        }

        private void FixedUpdate()
        {
            rigidbody2D.MovePosition(rigidbody2D.position + movement * speed * Time.fixedDeltaTime);
        }

    }
