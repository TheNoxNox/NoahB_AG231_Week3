using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base code taken from the joystick player example included with the asset package.
public class ChaserPlayer : MonoBehaviour
{
    public float speed;
    public float boostPower;
    public FixedJoystick movementJoystick;
    public FixedJoystick boostJoystick;
    public Rigidbody rb;
    public GameObject boostHitboxObj;
    public SphereCollider boostHitbox;
    public SphereCollider selfHitBox;

    public bool isCharging = false;
    public bool chargeOnCooldown = false;

    float maxChargeCD = 4.0f;
    public float chargeCooldown = 4.0f;

    float maxChargeDuration = 0.5f;
    public float chargeDuration = 0.1f;

    private void Awake()
    {
        if (!selfHitBox) { selfHitBox = GetComponent<SphereCollider>(); }
        if (!boostHitbox) { boostHitbox = boostHitboxObj.GetComponent<SphereCollider>(); }
        movementJoystick = ChaseGameManager.main.movementJoystick;
        boostJoystick = ChaseGameManager.main.boostJoystick;
        ChaseGameManager.main._player = this.gameObject;
    }

    public void FixedUpdate()
    {
        if (ChaseGameManager.main.gameOn)
        {
            Vector3 direction = Vector3.forward * movementJoystick.Vertical + Vector3.right * movementJoystick.Horizontal;
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

            if ((Mathf.Abs(boostJoystick.Vertical) >= 0.6f || Mathf.Abs(boostJoystick.Horizontal) >= 0.6f) && !chargeOnCooldown)
            {
                rb.velocity = Vector3.zero;

                Vector3 boostDir = Vector3.forward * boostJoystick.Vertical + Vector3.right * boostJoystick.Horizontal;

                rb.AddForce(boostDir * boostPower, ForceMode.VelocityChange);

                boostHitboxObj.SetActive(true);
                chargeOnCooldown = true;
                isCharging = true;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
       
    }

    private void Update()
    {
        if (isCharging)
        {
            chargeDuration -= Time.deltaTime;
            if(chargeDuration <= 0f)
            {
                isCharging = false;
                rb.AddForce(new Vector3(rb.velocity.x * -5f, rb.velocity.y * -5f, rb.velocity.z * -5f), ForceMode.Acceleration);
                boostHitboxObj.SetActive(false);
                chargeDuration = maxChargeDuration;                
            }
        }

        if (chargeOnCooldown)
        {
            chargeCooldown -= Time.deltaTime;
            if(chargeCooldown <= 0f)
            {
                chargeOnCooldown = false;
                chargeCooldown = maxChargeCD;
            }
        }
    }
}
