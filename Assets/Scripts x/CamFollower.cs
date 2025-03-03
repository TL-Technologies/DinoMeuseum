using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    public Transform following;
    public Vector3 offset;

    Vector3 velocity;
    public float smoothFactor = 1;
    bool isFollowing = true;

    [HideInInspector] public Vector3 initRot;
    void Start()
    {
        if (offset==Vector3.zero) offset = transform.position - following.position;
        initRot = transform.eulerAngles;
    }

    void FixedUpdate()
    {
        if (!isFollowing) return;

        Vector3 follow = following.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, follow, ref velocity, smoothFactor);
    }

    public void SetFollowingState(bool state)
    {
        isFollowing = state;
    }
}