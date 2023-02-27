using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move : MonoBehaviour
{
    public GameObject circle;

    public float speed = 1;
    public float stopDistance = 1;
    public int HP;
    public int DMG;
    bool trigger = false;
    public float attackCooldown = 1f;
    float time = 0f;
    Collider2D save;
    public Vector3 thistargetLocation = Vector3.zero;
    int b = 6;

    public Animator aim;

    //public Animator ani;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        thistargetLocation = circle.GetComponent<Echo_search>().targetLocation;

        if (thistargetLocation != Vector3.zero)
        {
            if (Vector3.Distance(transform.position, thistargetLocation) > stopDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, thistargetLocation, speed * Time.deltaTime);
            }
        }

        if (HP <= 0)
        {
            GameObject.Find("game_manager").GetComponent<Round_tracker>().enemiesKilled++;
            Destroy(this.gameObject);
        }

        time += Time.deltaTime;
        if (time > attackCooldown && save != null)
        {
            if (save.gameObject.tag == "Tree")
            {
                save.gameObject.GetComponent<Tree_logic>().HP -= DMG;
                aim.Play("Base Layer.zombittack", 0);
            }
            else
            {
                save.gameObject.GetComponent<Damagable_buildings>().HP -= DMG;
                aim.Play("Base Layer.zombittack", 0);
            }

            time = 0f;
        }

        /*animator*/
        /* ani.SetFloat("dirX", GetComponent<Rigidbody2D>().velocity.normalized.x);
         Debug.Log(GetComponent<Rigidbody2D>().velocity.normalized.x);
         ani.SetFloat("dirY", GetComponent<Rigidbody2D>().velocity.normalized.y);*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Building" || collision.gameObject.tag == "SeedBuilding" || collision.gameObject.tag == "TowerBuilding" || collision.gameObject.tag == "Tree")
        {
            save = collision;
            trigger = true;
            print("uso");
            
            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Building" || collision.gameObject.tag == "SeedBuilding" || collision.gameObject.tag == "TowerBuilding" || collision.gameObject.tag == "Tree")
        {
            save = null;
            trigger = false;

            print("izaso");
        }
    }

}
