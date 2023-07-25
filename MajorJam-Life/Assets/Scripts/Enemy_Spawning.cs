using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Enemy_Spawning : MonoBehaviour
{
    public Slider timer;
    public float game_time = 300;
    public float wave_time = 15;
    public float boundry = 100;
    public GameObject defense_cell;
    // Update is called once per frame
    void Update()
    {
        if (game_time <= 0) 
        {
            //you win
            SceneManager.LoadScene(3);
        }
        timer.value = game_time;
        if (wave_time >= 15)
        {
            if (game_time > 0)
            {
                for (int i = 0; i < Mathf.Pow(2,(300 - game_time)/60); i++)
                {
                    Instantiate(defense_cell,transform.position + new Vector3(Random.Range(-boundry,boundry), Random.Range(-boundry, boundry), 0), transform.rotation);
                }
            }
            wave_time = 0;
        }
        else
        {
            wave_time += Time.deltaTime;
        }
        game_time -= Time.deltaTime;
    }
}
