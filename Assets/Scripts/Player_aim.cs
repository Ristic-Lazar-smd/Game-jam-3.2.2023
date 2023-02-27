using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_aim : MonoBehaviour
{
    private Transform aimTransform;

    public GameObject hitBox;

    private float runningTimeBtwAttack = 1;
    public float timeBtwAttacks =1f;

    public bool canAttack = true;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);



        /*if (runningTimeBtwAttack <= 0)
        {
            canAttack = true;
            if (Input.GetKey(KeyCode.Mouse0) && this.GetComponentInParent<Player_Movement>().buildMode == false)
            {
                canAttack = false;
                StartCoroutine(activeFrames());
                runningTimeBtwAttack = timeBtwAttacks;

            }
        }
        else
        {

            runningTimeBtwAttack -= Time.deltaTime;
        }*/

        if (Input.GetKey(KeyCode.Mouse0)) StartCoroutine(activeFrames());
    }


    IEnumerator activeFrames()
    {
        hitBox.GetComponent<CapsuleCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        hitBox.GetComponent<CapsuleCollider2D>().enabled = false;
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
}
