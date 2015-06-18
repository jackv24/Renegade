using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerAttack))]
public class PlayerControl : MonoBehaviour
{
	private Vector3 inputVector;

    private PlayerMotor playerMotor;
    private PlayerAttack playerAttack;

	void Start()
	{
        playerMotor = GetComponent<PlayerMotor>();
        playerAttack = GetComponent<PlayerAttack>();
	}

	void Update()
	{
		//Get movement axis input
		inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		if(inputVector.magnitude > 1)
			inputVector.Normalize();

		//Move player
        playerMotor.Move(inputVector);

        //Attack Inputs
        if (Input.GetButtonDown("Attack 1") || Input.GetButtonDown("Submit"))
            playerAttack.Attack(1);
        if (Input.GetButtonDown("Attack 2"))
            playerAttack.Attack(2);
	}
}
