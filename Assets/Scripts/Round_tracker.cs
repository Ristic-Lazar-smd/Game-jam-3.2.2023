using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Round_tracker : MonoBehaviour
{
    public int round = 1;
    public float buildTimeout = 0f;
    public float buildTimer = 30f;
    public int numberOfEnemies;
    public bool buildPhase = true;
    public bool gameOver;
    public TMP_Text timer;
    private float seconds;
    public int enemiesKilled = 0;
    public int numberOfSeeds;
    public GameObject tree;

    public GameObject weapon;

    public int buildPhaseDuration=10;

    public AudioSource bgm;
    public AudioClip buildPhaseSong;
    public AudioClip wavePhaseSong;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true)
        {
            SceneManager.LoadScene("GameOver");
        }


        seconds = Mathf.FloorToInt(buildTimer % 60);
        timer.text = seconds.ToString();
        numberOfEnemies = round * 10 - 3;
        numberOfSeeds = round * 2 + 10;
        if(buildPhase)
        {
            this.GetComponent<Enemy_spawner>().enabled = false;
            //gameObject.GetComponent<Enemy_spawner>().stop = true;
            weapon.SetActive(false);

            //brisem sve prazne objekte
            for (var i = gameObject.GetComponent<Enemy_spawner>().listofallspawned.Count - 1; i > -1; i--)
            {
                if (gameObject.GetComponent<Enemy_spawner>().listofallspawned[i] == null)
                    gameObject.GetComponent<Enemy_spawner>().listofallspawned.RemoveAt(i);
            }
            for (var i = gameObject.GetComponent<Enemy_spawner>().listofallspawned.Count - 1; i > -1; i--)
            {
                Destroy(gameObject.GetComponent<Enemy_spawner>().listofallspawned[i]);
            }
            buildTimer -= Time.deltaTime;
            if(buildTimer <= buildTimeout)
            {
                buildPhase = false;
                buildTimer = buildPhaseDuration;
                this.GetComponent<Enemy_spawner>().stop = false;
                bgm.clip = wavePhaseSong;
                bgm.Play();
            }
        }
        else ///////////////WAVE FAZA
        {
            this.GetComponent<Enemy_spawner>().enabled = true;
            weapon.SetActive(true);
            if(enemiesKilled == numberOfEnemies)
            {
                enemiesKilled = 0;
                round++;
                tree.GetComponent<Tree_logic>().DropSeeds();
                buildPhase = true;
                bgm.clip = buildPhaseSong;
                bgm.Play();
            }
        }

    }
}
