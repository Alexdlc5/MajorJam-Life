using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Cursor : MonoBehaviour
{
    public float bio = 50;
    public TextMeshProUGUI bio_display;
    public bool canPlace = true;
    public GameObject turret;
    public GameObject Selected_Cell;
    public Button place;
    public Button select_turret;

    private HashSet<GameObject> interfering_towers = new HashSet<GameObject>();
    private void Start()
    {
        place.onClick.AddListener(Place);
        place.onClick.AddListener(selectTurret);
    }
    private void Update()
    {
        bio_display.text = "Bio: " + bio;
    }
    void Place()
    {
        if (interfering_towers.Count == 0 && bio >= 50)
        {
            bio -= 50;
            Instantiate(Selected_Cell, transform.position, transform.rotation);
        }
    }
    void selectTurret()
    {
        Selected_Cell = turret;
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
