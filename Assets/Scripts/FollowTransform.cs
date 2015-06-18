using UnityEngine;
using System.Collections;

public class FollowTransform : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        if (!target && GameObject.FindWithTag("Player"))
            target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if(target)
            transform.position = target.position;
    }
}
