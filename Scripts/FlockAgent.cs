using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlockAgent : MonoBehaviour
{
    Collider agentCollider;
    public Collider AgentCollider { get { return agentCollider; } }

    Vector3 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider>();
    }

    public void Move(Vector3 velocity, float smoothing) 
    {
        // smooth damping the velocity to avoid flickering
        velocity = Vector3.SmoothDamp(transform.forward, velocity, ref currentVelocity, smoothing);
        transform.forward = velocity;
        transform.position += velocity * Time.deltaTime;
    }
}
