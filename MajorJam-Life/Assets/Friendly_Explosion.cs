using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendly_Explosion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Defence_Cell>().health -= 7;
        }
    }
}
