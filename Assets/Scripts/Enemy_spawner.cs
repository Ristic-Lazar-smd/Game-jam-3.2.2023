using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{
    public List<GameObject> listofallspawned = new List<GameObject>(); 

    public GameObject zombi;
    public GameObject manager;
    public int numberOfEnemies;

    int toggle = 0;

    public float spawntime;
    public float countdown = 3;
    public bool stop=false;

    public int i = 0;

    private Vector3 spawnPosition;


    // Update is called once per frame
    private void Start()
    {
        stop = false;
    }
    void Update()
    {
        numberOfEnemies = manager.GetComponent<Round_tracker>().numberOfEnemies;

        countdown -= Time.deltaTime;
        if (countdown <= 0 && stop == false)
        {
            spawnEnemy();
            i++;
            if (i == numberOfEnemies)
            {
                stop = true;
                i = 0;
            }
            countdown = spawntime;
        }
    }

    void spawnEnemy()
    {
        toggle++; /*menja smer spawna*/

        int rand_x;
        int rand_y;
        int decide_x = Random.Range(0, 2);
        int decide_y = Random.Range(0, 2);
        /*Logika za spawn lokaciju*/
        if (toggle % 2 == 0)/* x primarno*/
        {
            if (decide_x == 1) /*Desno*/
            {
                rand_x = Random.Range(15, 20);
                rand_y = Random.Range(-20, 20);
            }
            else /*levo*/
            {
                rand_x = Random.Range(-20, -15);
                rand_y = Random.Range(-20, 20);
            }
        }
        else/* y primarno*/
        {
            if (decide_y == 1) /*Desno*/
            {
                rand_y = Random.Range(15, 20);
                rand_x = Random.Range(-20, 20);
            }
            else /*levo*/
            {
                rand_y = Random.Range(-20, -15);
                rand_x = Random.Range(-20, 20);
            }
        }

        spawnPosition.x = rand_x;
        spawnPosition.y = rand_y;

        //Instantiate(zombi, spawnPosition, Quaternion.identity);
        listofallspawned.Add((GameObject)Instantiate(zombi, spawnPosition, Quaternion.identity));
        

    }
}
