using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerJump : MonoBehaviour
{
    public float Speed = 10f;
    public float Gravity = -9.81f;

    private CharacterController _controller; //Add character controller component to player
    private Vector3 _velocity;
    private bool _groundedPlayer;
    private float _jumpHeight = 1.0f;

    void Start()
    {
        _controller = GetComponent<CharacterController>(); //reference to the cahracter controller component
    }

    void Update()
    {
        _groundedPlayer = _controller.isGrounded; //waws the character touching the ground during the last frame? Accessing character controller's isGrounded property

        if (_groundedPlayer && _velocity.y < 0) 
        {
            _velocity.y = 0f; //if the character was grounded in the last frame and is now moving in a negative velocity (falling down), set the velocity (speed and direction) to zero
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //predefined axes in Unity linked to WASD controllers
        _controller.Move(move * Time.deltaTime * Speed); //moves character in the given direction from our move vector3


        if (move != Vector3.zero)
        {
            transform.forward = move; //character rotates with directional movement
        }

        if (Input.GetButton("Jump") && _groundedPlayer) //predefined jump in unity mapped to the space bar
        {
            _velocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * Gravity); //Change velocity to represent a jumping behavior
        }

        _velocity.y += Gravity * Time.deltaTime; //setting velocity in the y direction to the acceleration of gravity in relation to our fps (Time.deltaTime)
        _controller.Move(_velocity * Time.deltaTime); //Movement based on velocity
    }
}
