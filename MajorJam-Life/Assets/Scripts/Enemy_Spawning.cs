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
    public float game_time = 240;
    public float wave_time = 15;
    public float minboundry = 10;
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
                for (int i = 0; i < (Mathf.Pow(2,(240 - game_time)/60) * wave_size_multiplier); i++)
                {
                  
                    int randomnum = Random.Range(1, 100);
                    if (game_time > 225)
                    {
                        boundry = 40;    
                    }
                    if (game_time > 150)
                    {
                        //first two quarters
                        if (randomnum < 25)
                        {
                            Instantiate(nuetrophil, transform.position + randomPosition(), transform.rotation);
                        }
                        Instantiate(defense_cell, transform.position + randomPosition(), transform.rotation);
                    }         
                    //second quarter
                    if (game_time < 225 && game_time > 150)
                    {
                        boundry = 50;
                        if (randomnum < 50)
                        {
                            Instantiate(defense_cell_b, transform.position + randomPosition(), transform.rotation);
                        }
                    }
                    //third quarter
                    if (game_time < 150)
                    {
                        boundry = 70;
                        if (randomnum < 50)
                        {
                            Instantiate(defense_cell_b, transform.position + randomPosition(), transform.rotation);
                            Instantiate(nuetrophil_b, transform.position + randomPosition(), transform.rotation);
                        }
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
   Vector3 randomPosition()
   {
        Vector3 randompos = new Vector3(0,0,0);
        bool xneg = false;
        bool yneg = false;
        while (randompos.x < minboundry && xneg == false || randompos.x > minboundry && xneg == true)
        {
            randompos = new Vector3(Random.Range(-boundry, boundry), 0, 0);
            if (randompos.x < 0) 
            {
                xneg = true;
            }
            else
            {
                xneg = false;
            }
        }
        while (randompos.y < minboundry && yneg == false || randompos.y > minboundry && yneg == true)
        {
            randompos = new Vector3(randompos.x, Random.Range(-boundry, boundry), 0);
            if (randompos.y < 0)
            {
                yneg = true;
            }
            else
            {
                yneg = false;
            }
        }
        return randompos;
    }
}
