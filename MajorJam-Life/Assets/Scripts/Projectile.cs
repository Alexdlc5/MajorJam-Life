using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 10;
    public float speed = 10;
    public ParticleSystem explosion;
    public GameObject hit;
    void Update()
    {
        transform.localPosition += transform.up * speed * Time.deltaTime;
        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            collision.GetComponent<Defence_Cell>().health -= 1;
            AudioSource sound = Instantiate(hit).GetComponent<AudioSource>();
            sound.pitch = Random.Range(.7f, 1.2f);
            sound.Play();
            Instantiate(explosion, transform.position, transform.rotation).GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
        else if (collision.tag.Equals("Cell") && collision.GetComponentInParent<Turret>())
        {
            Instantiate(hit);
            Instantiate(explosion, transform.position, transform.rotation).GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }
}
