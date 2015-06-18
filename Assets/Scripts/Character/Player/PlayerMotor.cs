using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMotor : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float smoothing = 0.5f;
    public float rotationSpeed = 0.25f;

    public float gravity = 20f;
	
    private Vector3 moveVector;

    public Animator animator;
    private float animSpeed = 0f;
    public float animSmoothing = 0.25f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Move(Vector3 inputVector)
    {
        //Calclulate movement vector (without resetting y for gravity)
        moveVector.x = Mathf.Lerp(moveVector.x, inputVector.x * moveSpeed, smoothing);
        moveVector.z = Mathf.Lerp(moveVector.z, inputVector.z * moveSpeed, smoothing);

        //If player is moving, rotate in movement direction (inputVector)
        if (inputVector.normalized.magnitude != 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(inputVector.normalized), rotationSpeed);

        //Apply gravity
        if (!controller.isGrounded)
            moveVector.y -= gravity * Time.deltaTime;
        else
            moveVector.y = 0;

        //Move the player moveVector per second
        controller.Move(moveVector * Time.deltaTime);

        //Calculate animation speed variable
        animSpeed = Mathf.Lerp(animSpeed, Mathf.Abs(controller.velocity.magnitude) / moveSpeed, animSmoothing);

        //Set animation Speed variable
        if (animator)
            animator.SetFloat("Speed", animSpeed);
    }
}
