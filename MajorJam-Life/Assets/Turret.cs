using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public bool is_core = false;
    public ParticleSystem explosion;
    public float health = 10;
    public GameObject target = null;
    public GameObject projectile;
    private float timer = .5f;
    // Update is called once per frame
    void Update()
    {
        if (is_core)
        {
            if (health <= 0)
            {
                //gameover
            }
        }
        if (is_core == false && target != null)
        {
            if (health <= 0)
            {
                Instantiate(explosion,transform.position,transform.rotation).GetComponent<ParticleSystem>().Play();
                Destroy(gameObject);
            }
            //look at
            Vector3 diff = target.transform.position - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            //shoot
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                Instantiate(projectile, transform.position, transform.rotation);
                timer = .5f;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && target == null || Vector2.Distance(transform.position, collision.gameObject.transform.position) < Vector2.Distance(transform.position, target.transform.position))
        {
            target = collision.gameObject;
        }
    }
}
