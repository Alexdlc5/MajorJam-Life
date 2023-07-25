using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject target = null;
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 diff = target.transform.position - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
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
