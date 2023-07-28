using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Enemy_Spawning : MonoBehaviour
{
    public TextMeshProUGUI timer_display;
    public float wave_size_multiplier = 1;
    public Slider timer;
    public float game_time = 300;
    public float wave_time = 15;
    public float boundry = 100;
    public GameObject defense_cell;
    public GameObject defense_cell_b;
    public GameObject nuetrophil;
    public GameObject nuetrophil_b;
    // Update is called once per frame
    void Update()
    {
        timer_display.text = (int)game_time + "s";
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
                for (int i = 0; i < (Mathf.Pow(2,(300 - game_time)/60) * wave_size_multiplier); i++)
                {
                    int randomnum = Random.Range(1, 100);
                    //every round
                    if (randomnum < 25)
                    {
                        Instantiate(nuetrophil, transform.position + new Vector3(Random.Range(-boundry, boundry), Random.Range(-boundry, boundry), 0), transform.rotation);
                    }
                    Instantiate(defense_cell,transform.position + new Vector3(Random.Range(-boundry,boundry), Random.Range(-boundry, boundry), 0), transform.rotation);
                    //second quarter
                    if (game_time < 225)
                    {
                        if (randomnum < 50)
                        {
                            Instantiate(defense_cell_b, transform.position + new Vector3(Random.Range(-boundry, boundry), Random.Range(-boundry, boundry), 0), transform.rotation);
                        }
                    }
                    //third quarter
                    if (game_time < 150)
                    {
                        Instantiate(defense_cell_b, transform.position + new Vector3(Random.Range(-boundry, boundry), Random.Range(-boundry, boundry), 0), transform.rotation);
                        if (randomnum < 50)
                        {
                            Instantiate(nuetrophil_b, transform.position + new Vector3(Random.Range(-boundry, boundry), Random.Range(-boundry, boundry), 0), transform.rotation);
                        }
                    }
                    //fourth quarter
                    if (game_time < 75)
                    {
                        Instantiate(defense_cell_b, transform.position + new Vector3(Random.Range(-boundry, boundry), Random.Range(-boundry, boundry), 0), transform.rotation);
                        Instantiate(nuetrophil_b, transform.position + new Vector3(Random.Range(-boundry, boundry), Random.Range(-boundry, boundry), 0), transform.rotation);
                    }
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
