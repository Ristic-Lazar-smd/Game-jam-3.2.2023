using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Player_Movement : MonoBehaviour
{

    // DamageableCharacter damageableCharacter;
    Rigidbody2D body;
    // Animator animator;

    float horizontal;
    float vertical;
    public float runSpeed = 20.0f;
    // GameObject attack;
    Vector3 mouse;
    public int select = 0;
    public GameObject seedBuilding;
    public GameObject towerBuilding;
    public GameObject tower1;
    public GameObject tower2;
    public Transform buildLocation;

    public GameObject manager;

    bool q = false;
    bool e = false;
    public bool canPlace = true;
    public bool buildMode = false;

    public GameObject qPopup;
    public GameObject ePopup;

    public GameObject placeholder;

    public Sprite spriteImgL;
    public Sprite spriteImgR;

    public Sprite spriteImg1L;
    public Sprite spriteImg2L;
    public Sprite spriteImg3L;

    public Sprite spriteImg1R;
    public Sprite spriteImg2R;
    public Sprite spriteImg3R;

    public Animator ani;
    private string currentState;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        /*ANIMACIJA*/
        ani.SetFloat("dirX", horizontal);
        ani.SetFloat("dirY", vertical);

        if (horizontal != 0 || vertical != 0)
        {
            ani.SetBool("isMoving", true);
        }
        else
        {
            ani.SetBool("isMoving", false);
        }

        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        /* if (horizontal > 0 && vertical == 0)
         {
             *//*ani.Play("Base Layer.Player_walk", 0);*//*
             ChangeAnimation("Player_walk");
             gameObject.GetComponent<SpriteRenderer>().flipX = false;
         }
         if (horizontal > 0 && vertical == 1)
         {
             ani.Play("Base Layer.Player_walk", 0);
             gameObject.GetComponent<SpriteRenderer>().flipX = false;
         }
         if (horizontal > 0 && vertical == -1)
         {
             ani.Play("Base Layer.Player_walk", 0);
             gameObject.GetComponent<SpriteRenderer>().flipX = false;
         }


         if (horizontal < 0 && vertical == 0)
         {
             ani.Play("Base Layer.Player_walk", 0);
             gameObject.GetComponent<SpriteRenderer>().flipX = true;
         }
         if (horizontal < 0 && vertical == 1)
         {
             ani.Play("Base Layer.Player_walk_L", 0);
             gameObject.GetComponent<SpriteRenderer>().flipX = true;
         }
         if (horizontal < 0 && vertical == -1)
         {
             ani.Play("Base Layer.Player_walk_L", 0);
             gameObject.GetComponent<SpriteRenderer>().flipX = true;
         }*/



        /*ANIMACIJA-END*/

        // Position clamp

        // initially, the temporary vector should equal the player's position
        Vector3 clampedPosition = transform.position;
        // Now we can manipulte it to clamp the y element
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -11.4f, 10.55f);
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -10f, 10f);
        // re-assigning the transform's position will clamp it
        transform.position = clampedPosition;


        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 final = Vector3.MoveTowards(buildLocation.transform.position, mousePosition, 2f); ;
        placeholder.transform.position = final;



        //IF SEEDS > NESTO
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (q == false)
            {
                qPopup.active = true;
                q = true;
                e = false;
                ePopup.active = false;
            }
            else if (q == true)
            {
                qPopup.active = false;
                q = false;
            }

            buildMode = true;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (e == false)
            {
                ePopup.active = true;
                e = true;
                q = false;
                qPopup.active = false;
            }
            else if (e == true)
            {
                ePopup.active = false;
                e = false;
            }
            buildMode = true;
        }
        if (q == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2) && (this.GetComponent<Tower_Building_Logic>().openUi == false) && (manager.GetComponent<Seeds>().seedStash >= 5))
            {
                placeholder.SetActive(true);
                q = false;
                qPopup.GetComponent<Image>().sprite = spriteImg2L;
                select = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1) && (this.GetComponent<Tower_Building_Logic>().openUi == false) && (manager.GetComponent<Seeds>().seedStash >= 5))
            {
                placeholder.SetActive(true);
             
                q = false;
                qPopup.GetComponent<Image>().sprite = spriteImg1L;

                select = 2;
            }
        }
        else if (e == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && (this.GetComponent<Tower_Building_Logic>().playerInventory[0] > 0))
            {
                placeholder.SetActive(true);
                e = false;
                ePopup.GetComponent<Image>().sprite = spriteImg1R;
                //ePopup.active = false;
                select = 3;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && (this.GetComponent<Tower_Building_Logic>().playerInventory[1] > 0))
            {
                placeholder.SetActive(true);
                e = false;
                //ePopup.active = false;
                ePopup.GetComponent<Image>().sprite = spriteImg2R;
                select = 4;
            }
        }

        if (select == 1 && (this.GetComponent<Tower_Building_Logic>().openUi == false))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && canPlace == true)
            {
                placeholder.SetActive(false);
                Instantiate(seedBuilding, final, Quaternion.identity);
                select = 0;
                buildMode = false;
                qPopup.active = false;
                qPopup.GetComponent<Image>().sprite = spriteImgL;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                placeholder.SetActive(false);
                qPopup.active = false;
                qPopup.GetComponent<Image>().sprite = spriteImgL;
            }
        }
        else if (select == 2 && (this.GetComponent<Tower_Building_Logic>().openUi == false))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && canPlace == true)
            {
                placeholder.SetActive(false);
                Instantiate(towerBuilding, final, Quaternion.identity);
                select = 0;
                buildMode = false;
                qPopup.active = false;
                qPopup.GetComponent<Image>().sprite = spriteImgL;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                placeholder.SetActive(false);
                qPopup.active = false;
                qPopup.GetComponent<Image>().sprite = spriteImgL;
            }
        }
        else if (select == 3)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && canPlace == true)
            {
                placeholder.SetActive(false);
                this.GetComponent<Tower_Building_Logic>().playerInventory[0]--;
                Instantiate(tower1, final, Quaternion.identity);
                select = 0;
                buildMode = false;
                ePopup.active = false;
                ePopup.GetComponent<Image>().sprite = spriteImgR;

            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                placeholder.SetActive(false);
                ePopup.active = false;
                ePopup.GetComponent<Image>().sprite = spriteImgR;
            }
        }
        else if (select == 4)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && canPlace == true)
            {
                placeholder.SetActive(false);
                this.GetComponent<Tower_Building_Logic>().playerInventory[1]--;
                Instantiate(tower2, final, Quaternion.identity);
                select = 0;
                buildMode = false;
                ePopup.active = false;
                ePopup.GetComponent<Image>().sprite = spriteImgR;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                placeholder.SetActive(false);
                ePopup.active = false;
                ePopup.GetComponent<Image>().sprite = spriteImgR;
            }
        }

    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed).normalized * runSpeed;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Seed")
        {
            manager.GetComponent<Seeds>().seedStash++;
            Destroy(collision.gameObject);
        }
    }




    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }



    /*   void ChangeAnimation(string newState)
       {
           if (currentState == newState) return;

           ani.Play(newState);

           currentState = newState;
       }*/
}