using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Sounds : MonoBehaviour
{
    public AudioSource playSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySoundEffect()
    {
        playSound.Play();
    }
}
