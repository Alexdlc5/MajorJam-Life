using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploAnimManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SpriteRenderer>().sprite.name.Equals("Guy_Exploding-Sheet_17"))
        {
            GetComponent<Animator>().speed = 0;
        }
    }
}
