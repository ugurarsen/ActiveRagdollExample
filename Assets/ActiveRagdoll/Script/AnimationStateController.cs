using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator _animator;

    private float velocity = 0f;
    public float acceleration = 0.1f;
    public float deseleration = 0.5f;
    private int VelocityHash;
    public float maxVelocity = 1f;
    private Rigidbody rb;
    void Start()
    {
        _animator = GetComponent<Animator>();
        VelocityHash = Animator.StringToHash("Velocity");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        if (forwardPressed && velocity < maxVelocity)
        {
            velocity += Time.deltaTime * acceleration;
        }

        if (!forwardPressed && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * deseleration;
        }

        if (!forwardPressed && velocity < 0.0f)
        {
            velocity = 0.0f;
        }

        rb.velocity = Vector3.forward * velocity * 20;
        
        _animator.SetFloat(VelocityHash,velocity);

    }
}
