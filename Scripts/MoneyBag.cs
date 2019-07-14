using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MoneyBag : MonoBehaviour
{

    public float amount;

    GameManager gameManager;

    public GameObject particle;

    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        renderer = GetComponent<SpriteRenderer>();
        amount = Random.Range(0.1f* gameManager.maxMoney, gameManager.maxMoney);

        renderer.color = new Color(1, 1, 1, 0);
        renderer.DOFade(1, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameManager.money += amount;
            if(particle)
            Destroy(Instantiate(particle, transform.position, Quaternion.identity),2f);

            Destroy(gameObject);
        }
    }
}
