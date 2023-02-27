using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed_counter : MonoBehaviour
{
    public int seedCounter = 0;
    public float timeInterval = 3f;
    float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            time += Time.deltaTime;
            if (time > timeInterval)
            {
                time = 0.0f;
                seedCounter++;
                Debug.Log("seed");

            }
    }
}
