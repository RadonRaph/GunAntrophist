using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public GameObject Aspect;
    public float life = 20;
    public float speed = 5;

    Player player;
    Rigidbody2D rb;

    public LayerMask layer;

    public enum mode
    {
        zombie,
        normal
    }

    public mode EnemyMode;

    public GameObject joyPrefab;

    public Vector2 startPosition;
    public GameManager gameManager;

    AIDestinationSetter ai;
    // Start is called before the first frame update
    void Start()
    {
        

        player = GameObject.Find("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ai = GetComponent<AIDestinationSetter>();

        life = 20 + gameManager.difficulty;

        EnemyMode = mode.zombie;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isActive == false)
            return;

        Vector2 direction;
        float distance;
        if (EnemyMode == mode.zombie)
        {
             direction = player.transform.position - transform.position;
            ai.target = player.transform;
            distance = Vector2.Distance(player.transform.position, transform.position);
        }
        else
        {
            direction = startPosition - transform.position.ToVector2XY();
            ai.target = GameObject.Find("Porte").transform;
            distance = Vector2.Distance(startPosition, transform.position);
        }

        

        if (Physics2D.Linecast(transform.position, transform.position.ToVector2XY() + (direction.normalized*2), layer).transform)
            direction = new Vector2(Random.Range(-30,30), Random.Range(0, 40)) - transform.position.ToVector2XY();

        direction = direction.normalized;

        if (direction.x < 0)
        {
            Aspect.transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            Aspect.transform.localScale = new Vector2(1, 1);
        }


        if (distance > speed / 4)
        {
           // rb.AddForce(direction * speed);
        }
        else if(EnemyMode == mode.zombie)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().money -= 0.1f * GameObject.Find("GameManager").GetComponent<GameManager>().maxMoney;
            player.hit();
            Death();
        }
    }

    private void LateUpdate()
    {
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -speed, speed), Mathf.Clamp(rb.velocity.y, -speed, speed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" && EnemyMode == mode.zombie)
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            life -= bullet.damage;

            for (int i = 0; i < Aspect.transform.childCount; i++)
            {
                if (Aspect.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>())
                {
                    Aspect.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().DOKill();
                    Aspect.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    Aspect.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f);
                }
                    
            }

            GetComponent<Rigidbody2D>().AddForce(collision.attachedRigidbody.velocity * bullet.knockdown);

            if (life <= 0)
            {
                Death();
                GameObject.Find("GameManager").GetComponent<GameManager>().killCount++;
            }

        }
    }

    void Death()
    {
        EnemyMode = mode.normal;
        Destroy(gameObject, 2f);
        Instantiate(joyPrefab, transform.position, Quaternion.identity, transform);
    }
}
