using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_making_placeholder : MonoBehaviour
{
    public GameObject turretPlaceholder = null;
    public bool? queue = false;
    public int buildTime;
    public GameObject tower1;
    public GameObject tower2;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Tower1Corrutine()
    {
        anim.Play("Base Layer.BuildStart", 0);
        yield return new WaitForSeconds(buildTime);
        anim.Play("Base Layer.BuildEnd", 0);
        turretPlaceholder = tower1;
        Debug.Log("tower1 done");
    }
    public IEnumerator Tower2Corrutine()
    {
        anim.Play("Base Layer.BuildStart", 0);
        yield return new WaitForSeconds(buildTime);
        anim.Play("Base Layer.BuildEnd", 0);
        turretPlaceholder = tower2;
        Debug.Log("tower2 done");
    }
}
