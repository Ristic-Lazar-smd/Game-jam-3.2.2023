using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_animation : MonoBehaviour
{
    Rigidbody2D body;
    Animator animator;

    float xaxis;
    // Start is called before the first frame update
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("dirX", body.velocity.normalized.x);
        animator.SetInteger("dirxint", (int)body.velocity.normalized.x);

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            print("tset");
        }
    }
}
