using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Defence_Cell : MonoBehaviour
{
    public float bio_value = 10;
    public float speed = 2;
    public float health = 3;
    public float attack_distance = 1;
    public ParticleSystem explosion;
    GameObject target;
    private float timer = 1; 

    // Update is called once per frame
    void Update()
    {
        //if dead
        if (health <= 0)
        {
            GameObject.FindAnyObjectByType<Cursor>().bio += bio_value;
            Instantiate(explosion, transform.position, transform.rotation).GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
        //moves to target
        if (target != null && Vector2.Distance(transform.position, target.transform.position) > 1)
        {
            Vector3 diff = target.transform.position - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            transform.localPosition += transform.up * speed * Time.deltaTime;
        }
        //reaches target
        else if (target != null && Vector2.Distance(transform.position, target.transform.position) <= attack_distance)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else if (timer < 0) 
            {
                timer = 1;
                target.GetComponent<Turret>().health -= 1;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Turret") || collision.gameObject.tag.Equals("Core") && (target == null || Vector2.Distance(transform.position, collision.gameObject.transform.position) < Vector2.Distance(transform.position, target.transform.position)))
        {
            target = collision.gameObject;
        }
    }
}
