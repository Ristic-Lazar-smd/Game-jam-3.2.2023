using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_shoot : MonoBehaviour
{
    public Transform pfBullet;

    float countdown = 0;
    public float cooldown = 0.5f;
    public bool canShoot = true;

    private void Awake()
    {
        countdown = cooldown;
    }

    void Update()
    {
        if (!canShoot)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                countdown = cooldown;
                canShoot = true;
            }
        }
    }

    public void Shooting()
    {
        if (canShoot)
        {
            Transform bullet = Instantiate(pfBullet, transform.position, Quaternion.identity);
            //bullet.GetComponent<Bullet>().dir = GetComponent<EchoSearch>().shootDir;
            bullet.GetComponent<Bullet_Shoot_1>().Setup(GetComponent<Basic_Tower_Shot>().shootDir.normalized);
            canShoot = false;
            Update();
        }
    }
}
