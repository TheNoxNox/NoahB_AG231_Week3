using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public float runSpeed = 10f;

    Vector3 playerTarget;

    Rigidbody rb;
    //public SphereCollider hitBox;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
        if (!rb)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }
    private void FixedUpdate()
    {
        playerTarget = ChaseGameManager.main.PlayerPosition;

        Vector3 playerDirection = (transform.position - playerTarget).normalized;

        rb.AddForce(playerDirection * runSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerHB>())
        {
            ChaseGameManager.main.numberOfEnemies -= 1;
            Destroy(gameObject);
        }
    }
}
