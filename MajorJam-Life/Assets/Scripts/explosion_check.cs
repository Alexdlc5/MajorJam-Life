using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_check : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Explosion")
        {
            GetComponentInParent<Turret>().health -= 3;
        }
    }
}
