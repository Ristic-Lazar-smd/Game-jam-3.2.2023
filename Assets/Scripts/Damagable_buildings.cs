using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable_buildings : MonoBehaviour
{
    public int HP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HP<=0)
        {

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponentInParent<Building_detection>().buildings.Add(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponentInParent<Building_detection>().buildings.Remove(this.gameObject);
        }
    }
}
