using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dmg_od_weapona : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "weapon")
        {
            player.GetComponent<Enemy_move>().HP -= collision.gameObject.GetComponent<Player_dmg>().weaponDmg;
            print("joj");
        }
    }
}
