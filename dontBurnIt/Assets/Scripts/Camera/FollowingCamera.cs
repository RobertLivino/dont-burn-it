using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 2.25f, -10f);
    private float smoothTime = 0.2f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
    
    void FixedUpdate()
    {
        if (PlayerManager.cameraShouldFollow)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }

        
    }

}
