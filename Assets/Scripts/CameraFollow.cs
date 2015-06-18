using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothing = 0.25f;
    public float forward = 2.0f;

    private Vector3 initialPosition;

    private Vector3 targetPosition;

    private Vector3 inputVector;
    private float inputVectorMagnitude;

    private GameStats gameStats;

    void Start()
    {
        if (!target && GameObject.FindWithTag("Player"))
            target = GameObject.FindWithTag("Player").transform;

        if(!target)
            Debug.Log("No player or camera target!");

        initialPosition = transform.position - target.position;

        gameStats = GameObject.FindWithTag("GameController").GetComponent<GameStats>();
    }

    void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (inputVector.magnitude > 1)
            inputVector.Normalize();
        inputVectorMagnitude = Mathf.Abs(inputVector.magnitude);
    }

    void LateUpdate()
    {
        if (target && !gameStats.isGamePaused)
        {
            targetPosition = target.position + target.transform.forward * inputVectorMagnitude * forward + initialPosition;

            transform.position = Vector3.Slerp(transform.position, targetPosition, smoothing);
        }
    }
}
