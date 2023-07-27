using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Turret : MonoBehaviour
{
    public bool is_core = false;
    public bool is_factory = false;
    public float BPS_factory = 1;
    public ParticleSystem explosion;
    public float health = 10;
    public GameObject target = null;
    public GameObject projectile;
    public AudioSource shoot_sound;
    private float timer = .5f;
    private Cursor cursor;
    private void Start()
    {
        if (is_factory)
        {
            cursor = GameObject.FindGameObjectWithTag("Cursor").GetComponent<Cursor>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (is_core)
        {
            if (health <= 0)
            {
                //gameover
                SceneManager.LoadScene(2);
            }
        }
        else
        {
            if (health <= 0)
            {
                Instantiate(explosion, transform.position, transform.rotation).GetComponent<ParticleSystem>().Play();
                Destroy(gameObject);
            }
        }
        if (is_factory == false && is_core == false && target != null)
        {
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
                shoot_sound.pitch = Random.Range(.7f, 1.2f);
                shoot_sound.Play();
                Instantiate(projectile, transform.position + (2 * transform.up), transform.rotation);
                timer = .5f;
            }
        }
        if (is_factory)
        {
            cursor.bio += Time.deltaTime * BPS_factory;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!is_core && collision.tag == "Enemy" && (target == null || Vector2.Distance(transform.position, collision.gameObject.transform.position) < Vector2.Distance(transform.position, target.transform.position)))
        {
            target = collision.gameObject;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Explosion")
        {
            health -= 3;
        }
    }
}
