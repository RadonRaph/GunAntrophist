using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    BoxCollider2D collider2D;
    public GameObject hitObjet;

    public float damage;
    public float knockdown;
    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" || collision.tag != "Bullet")
        {
            if (hitObjet)
            Destroy(Instantiate(hitObjet, transform.position, Quaternion.identity), 3f);



            Destroy(gameObject);
        }
    }
}
