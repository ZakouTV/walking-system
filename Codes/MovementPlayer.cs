using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController character;
    private Vector3 velocityofplayer;
    public float jumpy = 0.8f;
    public float speed = 5f;
    private bool isGrounded;
    public float gravity = -9.8f;
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

     
    void Update()
    {
        isGrounded = character.isGrounded;
    }
    public void movements(Vector2 input)
    {
        Vector3 positions = Vector3.zero;
        positions.x = input.x;
        positions.z = input.y;
        character.Move(transform.TransformDirection(positions) * speed * Time.deltaTime);
        velocityofplayer.y += gravity * Time.deltaTime;
        if (isGrounded && velocityofplayer.y < 0)
            velocityofplayer.y = -2f;
        character.Move(velocityofplayer * Time.deltaTime);
        Debug.Log(velocityofplayer.y);

    }
    public void Jump()
    {
        if (isGrounded)
        {
            velocityofplayer.y = Mathf.Sqrt(jumpy * -3.0f * gravity);
        }
    }
}
