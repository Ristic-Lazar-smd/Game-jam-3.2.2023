using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2_aoe_hit : MonoBehaviour
{
    public int DMG;
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
        if (collision.gameObject.tag == "AOE")
        {
            this.GetComponent<Enemy_move>().HP -= DMG;

        }
    }
}
