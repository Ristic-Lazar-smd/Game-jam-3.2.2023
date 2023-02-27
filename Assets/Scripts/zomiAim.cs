using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zomiAim : MonoBehaviour
{
    private Transform aimmTransform;


    private void Awake()
    {
        aimmTransform = transform.Find("aim");
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 aimDirection = (gameObject.GetComponent<Enemy_move>().thistargetLocation - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimmTransform.eulerAngles = new Vector3(0, 0, angle);

    }



}
