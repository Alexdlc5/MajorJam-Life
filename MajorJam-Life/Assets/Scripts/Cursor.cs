using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Cursor : MonoBehaviour
{
    public AudioSource placesound;
    public float bio = 50;
    public TextMeshProUGUI bio_display;
    public TextMeshProUGUI price_display;
    public TextMeshProUGUI cell_name_display;
    public SpriteRenderer selected_cell_display;
    public SpriteRenderer cannon_display;
    public bool canPlace = true;
    public GameObject turret;
    public float turret_price = 50;
    public float factory_price = 50;
    public GameObject factory;
    public GameObject Selected_Cell;
    public Button place;
    public Button select_turret;
    public Button select_factory;

    private HashSet<GameObject> interfering_towers = new HashSet<GameObject>();
    private void Start()
    {
        place.onClick.AddListener(Place);
        select_turret.onClick.AddListener(selectTurret);
        select_factory.onClick.AddListener(selectFactory);
        Selected_Cell = turret;
        price_display.text = "Bio Cost: " + turret_price;
        cell_name_display.text = "Turret Cell";
        selected_cell_display.sprite = Selected_Cell.GetComponent<SpriteRenderer>().sprite;
    }
    private void Update()
    {
        bio_display.text = "Bio: " + (int)bio;
    }
    void Place()
    {
        if (interfering_towers.Count == 0)
        {
            if (Selected_Cell == turret && bio >= turret_price)
            {

                bio -= turret_price;
                placesound.Play();
                Instantiate(Selected_Cell, transform.position, transform.rotation);
            }
            else if (Selected_Cell == factory && bio >= factory_price)
            {
                bio -= factory_price;
                placesound.Play();
                Instantiate(Selected_Cell, transform.position, transform.rotation);
            }
           
        }
    }
    void selectFactory()
    {
        Selected_Cell = factory;
        price_display.text = "Bio Cost: " + factory_price;
        cell_name_display.text = "Factory Cell";
        cannon_display.color = new Color(cannon_display.color.r, cannon_display.color.g, cannon_display.color.b, 0);
        selected_cell_display.sprite = Selected_Cell.GetComponent<SpriteRenderer>().sprite;
    }
    void selectTurret()
    {
        Selected_Cell = turret;
        price_display.text = "Bio Cost: " + turret_price;
        cell_name_display.text = "Turret Cell";
        cannon_display.color = new Color(cannon_display.color.r, cannon_display.color.g, cannon_display.color.b, 1);
        selected_cell_display.sprite = Selected_Cell.GetComponent<SpriteRenderer>().sprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Vector2.Distance(transform.position, collision.gameObject.transform.position) < 5 && collision.tag == "Cell" && !interfering_towers.Contains(collision.gameObject))
        {
            interfering_towers.Add(collision.gameObject);
            canPlace = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Cell")
        {
            interfering_towers.Remove(collision.gameObject);
        }
    }
}
