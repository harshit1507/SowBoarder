using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1f;
    [SerializeField] private float boostSpeed = 30f;
    [SerializeField] private float baseSpeed = 20f;
    
    private Rigidbody2D rb;
    private SurfaceEffector2D surfaceEffector2D;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            surfaceEffector2D.speed *= 0.9f;
            return;
        }

        RotatePlayer();
        RespondToBoost();
    }

    private void RespondToBoost()
    {
        //if we push up, then speed up, otherwise stay at normal speed
        // access the surface effect 2D and change the speed
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-torqueAmount);
        }
    }

    public void SetIsDead(bool value)
    {
        this.isDead = value;
    }

    public bool IsDead()
    {
        return isDead;
    }
}
