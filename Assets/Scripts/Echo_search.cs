using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo_search : MonoBehaviour
{
    GameObject targetedObject;

    CircleCollider2D cc;
    internal Vector3 shootDir;
    internal bool detected = false;
    public int expandRadius = 10;
    public float echoDelay = 0.001f;

    public Vector3 targetLocation;

    public bool canShoot = true;
    private Collider2D save;

    public Animator ani;

    void Start()
    {
        /*Physics2D.IgnoreLayerCollision(8, 8, true);
        Physics2D.IgnoreLayerCollision(8, 6, true);
        Physics2D.IgnoreLayerCollision(8, 3, true);*/
        
        cc = gameObject.GetComponent<CircleCollider2D>();
    }

    void FixedUpdate()
    {
        if (!detected)
        {
            detected = true;
            StartCoroutine(Expand());
        }

        if (save == null)
        {
            canShoot = true;
        }
    }


    IEnumerator Expand()
    {
        cc.radius = 0.5f;
        if (canShoot)
        {
            while (cc.radius <= (0.1 * expandRadius))
            {
                cc.radius += 0.1f;
                if (!detected) { break; }
                yield return new WaitForSeconds(echoDelay);
            }
        }
        else
        {
            detected = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SeedBuilding" || collision.gameObject.tag == "TowerBuilding" || collision.gameObject.tag == "Building" || collision.gameObject.tag == "Tree")
        {
            save = collision;
            targetLocation = collision.gameObject.transform.position;

            detected = false;
            canShoot = false;

            /*animator */
            if ((collision.gameObject.transform.position.x - this.gameObject.transform.position.x) > 0)
            {
                ani.Play("Base Layer.run", 0);
                gameObject.GetComponentInParent<SpriteRenderer>().flipX = false;

            }
            else if ((collision.gameObject.transform.position.x - this.gameObject.transform.position.x) < 0)
            {
                ani.Play("Base Layer.run", 0);
                gameObject.GetComponentInParent<SpriteRenderer>().flipX = true;
            }
        }
        
    }
}
