using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Shoot_1 : MonoBehaviour
{

    public Vector3 dir;
    public float bulletSpeed = 10;
    public int DMG;


    private void Awake()
    {
        //Physics2D.IgnoreLayerCollision(0, 0, true);
    }

    public void Setup(Vector3 shootDir)
    {
        //dir = new Vector3(shootDir.x, shootDir.y).normalized;
        dir = shootDir;
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(shootDir));
        Destroy(gameObject, 2f); //brise gameobject na kome je ova skripta posle 2s

    }

    void FixedUpdate()
    {
        transform.position += bulletSpeed * Time.deltaTime * dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy_move>().HP -= DMG;
            Destroy(this.gameObject);
        }
        
    }



    //<----------------NEBITNA STVAR, KORISTIM SAMO DA PREVEDEM UGAO---------------->//
    public float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
