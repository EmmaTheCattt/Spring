using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_script : MonoBehaviour
{
    public Rigidbody2D RB;
    public Collider2D Col;
    public SpriteRenderer SR;

    private Vector3 movement;

    public float side_speed = 2;
    public float side_speed_run = 6;

    public float y_speed = 1;
    public float y_speed_run = 3;

    private float direction_x;
    private float direction_y;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Col = GetComponent<Collider2D>();
        SR = GetComponent<SpriteRenderer>();
        direction_x = 0;
        direction_y = 0;
}

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        transform.position += movement * Time.deltaTime;


        direction_x -= 0.1f * Time.deltaTime;
        direction_y -= 0.1f * Time.deltaTime;

        if (direction_x < 0)
        {
            direction_x = 0;
        }

        if (direction_y < 0)
        {
            direction_y = 0;
        }
    }



    private void CheckInput()
    {
        //input D
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            direction_x = 1;
            SR.flipX = false;
        }

        //input A
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            direction_x = -1;
            SR.flipX = true;
        }

        //input W
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            direction_y = 1;
        }

        //input S
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            direction_y = -1;
        }

        //Makes the vector.
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            movement = new Vector3(direction_x * side_speed_run, direction_y * y_speed_run, 0); 
        }
        else
        {
            movement = new Vector3(direction_x * side_speed, direction_y * y_speed, 0);
        }
    }
}
