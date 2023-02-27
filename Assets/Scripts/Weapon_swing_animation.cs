using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_swing_animation : MonoBehaviour
{
    public Animator anim;
    public GameObject player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
                anim.Play("Base Layer.swing", 0);
        }
    }

}
