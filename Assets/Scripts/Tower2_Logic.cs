using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2_Logic : MonoBehaviour
{
    float timeStart = 2f;
    float timeStop = 3f;
    float time = 0f;
    public GameObject circle;
    public Animator aim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //Debug.Log(time);
        if(time > timeStart)
        {
            circle.SetActive(true);
            aim.Play("Base Layer.attack", 0);
            if (time > timeStop)
            {
                circle.SetActive(false);
                time = 0f;
            }
        }
    }
}
