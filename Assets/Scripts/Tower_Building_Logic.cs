using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tower_Building_Logic : MonoBehaviour
{
    public int buildTime;
    public GameObject tower1;
    public GameObject tower2;
    //public GameObject tower3;
    public GameObject seedBuilding;
    public GameObject towerBuilding;
    //public List<GameObject> towerList;
    public int[] playerInventory = { 0, 0, 0 };
    //bool trigger = false;
    public bool openUi = false;
    //bool queue = false;
    List<GameObject> buildings;
    float min = 1000;
    public GameObject closestBuilding;
    public GameObject manager;
    public GameObject? save;
    public GameObject popup;
    private GameObject transPopup;
    public TMP_Text tower1counter;
    public TMP_Text tower2counter;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        buildings = this.gameObject.GetComponent<Building_detection>().buildings;
    }

    // Update is called once per frame
    void Update()
    {
        tower1counter.text = playerInventory[0].ToString();
        tower2counter.text = playerInventory[1].ToString();


        if (buildings.Count == 0)
        {
            closestBuilding = null;
            min = 1000;
            Destroy(transPopup);
        }
        else if (buildings.Count > 0)
        {
            foreach (GameObject building in buildings)
            {
                if (Vector2.Distance(this.gameObject.transform.position, building.transform.position) < min)
                {
                    min = Vector2.Distance(this.gameObject.transform.position, building.transform.position);
                    closestBuilding = building;

                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && closestBuilding.tag == "TowerBuilding")
        {
            Debug.Log("FFFFFFFFFF");
            if (closestBuilding != null)
            {
                save = closestBuilding;
            }

            //foreach (GameObject building in buildings)
            //{
            //    if (Vector2.Distance(this.gameObject.transform.position, building.transform.position) < min)
            //    {
            //        min = Vector2.Distance(this.gameObject.transform.position, building.transform.position);
            //        closestBuilding = building;
            //    }
            //}
            ////////////////////////////////////////////////////////////TOWER_BUILDING////////////////////////////
            //if (closestBuilding.tag == "TowerBuilding")
            //{
            if (closestBuilding.GetComponent<Tower_making_placeholder>().turretPlaceholder != null)
            {
                Debug.Log("---COLLECTED---");
                if (closestBuilding.GetComponent<Tower_making_placeholder>().turretPlaceholder == tower1)
                {
                    playerInventory[0]++;
                }
                else if (closestBuilding.GetComponent<Tower_making_placeholder>().turretPlaceholder == tower2)
                {
                    playerInventory[1]++;
                }

                save.GetComponent<Tower_making_placeholder>().queue = false;
                closestBuilding.GetComponent<Tower_making_placeholder>().turretPlaceholder = null;
            }
            else
            {
                openUi = true;
                Debug.Log("---UI OPEN---");

                popup.transform.position = new Vector3(save.transform.position.x, save.transform.position.y + 2f, 0);
                transPopup = Instantiate(popup, popup.transform.position, Quaternion.identity);
                //else if (Input.GetKeyDown(KeyCode.Alpha3))
                //{
                //    this.GetComponent<Player_Movement>().select = 0;
                //    queue = true;
                //    openUi = false;
                //    StartCoroutine(Tower3Corrutine());

                //    //popup-DONE
                //}
            }
            //}

        }
        if (openUi == true && save.GetComponent<Tower_making_placeholder>().queue == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

                if (closestBuilding != null)
                {
                    save = closestBuilding;
                }
                Destroy(transPopup);
                save.GetComponent<Tower_making_placeholder>().queue = true;
                openUi = false;
                StartCoroutine(save.GetComponent<Tower_making_placeholder>().Tower1Corrutine());


                //popup-DONE
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (closestBuilding != null)
                {
                    save = closestBuilding;
                }
                Destroy(transPopup);
                save.GetComponent<Tower_making_placeholder>().queue = true;
                openUi = false;
                StartCoroutine(save.GetComponent<Tower_making_placeholder>().Tower2Corrutine());

                //popup-DONE
            }
        }
        ////////////////////////////////////////////////////////////SEEDS_BUILDING////////////////////////////

        if (Input.GetKeyDown(KeyCode.F) && closestBuilding.tag == "SeedBuilding")
        {
            manager.GetComponent<Seeds>().seedStash += closestBuilding.GetComponent<Seed_counter>().seedCounter;
            closestBuilding.GetComponent<Seed_counter>().seedCounter = 0;
        }



    }

    //IEnumerator Tower1Corrutine()
    //{
    //    yield return new WaitForSeconds(buildTime);
    //    save.GetComponent<Tower_making_placeholder>().turretPlaceholder = tower1;
    //    Debug.Log("tower1 done");
    //}
    //IEnumerator Tower2Corrutine()
    //{
    //    yield return new WaitForSeconds(buildTime);
    //    save.GetComponent<Tower_making_placeholder>().turretPlaceholder = tower2;
    //    Debug.Log("tower2 done");
    //}
    //IEnumerator Tower3Corrutine()
    //{
    //    yield return new WaitForSeconds(buildTime);
    //    towerList.Add(tower3);
    //    Debug.Log("tower3 done");
    //}
}
