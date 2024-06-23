using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    public CharacterController2D Controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }

    void FixedUpdate()
    {
        Controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }
}
