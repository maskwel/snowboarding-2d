using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotateAmount = 1f;
    [SerializeField] float baseSpeed = 18f;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] GameObject levelSprite;
    Rigidbody2D rb2d;
    SurfaceEffector2D effector2D;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        effector2D = levelSprite.GetComponent<SurfaceEffector2D>();
    }

    void Update()
    {
        PlayerRotate();
        PlayerBoost();
    }

    void PlayerBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            effector2D.speed = boostSpeed;
        }
        else 
        {
            effector2D.speed = baseSpeed;
        }
    }

    void PlayerRotate()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(rotateAmount);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-rotateAmount);
        }
    }
}
