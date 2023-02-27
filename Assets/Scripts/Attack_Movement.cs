using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public float fRadius = 3.0f;
    private Transform pivot;
    //public float speed;
    //public float rotationOffset;


    void Start()
    {
        pivot = new GameObject().transform;
        transform.parent = pivot;

        //cube = GameObject.FindWithTag("Player");
        //   center = cube.transform;
        //  transform.position = (transform.position - center.position).normalized * radius + center.position;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 v3Pos = Camera.main.WorldToScreenPoint(target.position);
        v3Pos = Input.mousePosition - v3Pos;
        float angle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;

        pivot.position = target.position;
        pivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);





        /*
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

       // Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        */
        // targetPos.z = 0;
        // transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

    }


}
