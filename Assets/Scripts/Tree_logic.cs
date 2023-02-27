using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_logic : MonoBehaviour
{
    public int HP;
    public GameObject manager;
    public GameObject seed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            manager.GetComponent<Round_tracker>().gameOver = true;
        }
    }

    public void DropSeeds()
    {
        int numberOfSeeds = manager.GetComponent<Round_tracker>().numberOfSeeds;

        for (int i = 0; i < numberOfSeeds; i++)
        {
            Vector3 spawn = this.transform.position;
            spawn.x += Random.Range(-7, 7);
            spawn.y += Random.Range(-4, -3);
            Instantiate(seed, spawn, Quaternion.identity);
        }
    }
}

