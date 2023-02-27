using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement_check : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer sprite;
    bool trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger == true)
        {
            player.GetComponent<Player_Movement>().canPlace = false;
            sprite.color = new Color(1, 0, 0, 1);
        }
        else if(trigger == false)
        {
            player.GetComponent<Player_Movement>().canPlace = true;
            sprite.color = new Color(1, 1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Building" || collision.gameObject.tag == "SeedBuilding" || collision.gameObject.tag == "TowerBuilding" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "weapon")
        {
            trigger = true;
            
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Building" || collision.gameObject.tag == "SeedBuilding" || collision.gameObject.tag == "TowerBuilding" || collision.gameObject.tag == "Player")
        trigger = false;
        
    }
}
