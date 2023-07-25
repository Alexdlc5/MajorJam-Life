using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 10;
    public float speed = 10;
    public ParticleSystem explosion;
    void Update()
    {
        transform.localPosition += transform.up * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            collision.GetComponent<Defence_Cell>().health -= 1;
            Instantiate(explosion, transform.position, transform.rotation).GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }
}
