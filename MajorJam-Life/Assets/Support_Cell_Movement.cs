using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support_Cell_Movement : MonoBehaviour
{
    public float speed = 10;
    private void Update()
    {
        Vector3 movement = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.W))
        {
            movement.y = speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.y = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x = speed;
        }
        transform.position += movement * Time.deltaTime; 
    }
}
