using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{

    public float speed;

    public Weapon weapon;
    public GameObject weaponObj;

    public GameObject playerAspect;

    public GameManager gameManager;

    Rigidbody2D rb;


    float weaponReloadTime;

    public SpriteSheet legsSpriteSheet;
    float legDelay = 8;
    int legId = 0;

    public SpriteRenderer legs;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isActive == false)
            return;

        rb.AddForce(InputExtend.Direction2D() * speed);

        Vector2 target = InputExtend.WorldMousePos() - transform.position.ToVector2XY();
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        float modifier = 1;

        if (InputExtend.WorldMousePos().x < transform.position.x)
        {
           // angle = Mathf.Clamp(Mathf.Abs(angle), 130, 210)*Mathf.Sign(angle);
            playerAspect.transform.localScale = new Vector2(1, 1);
            weaponObj.GetComponent<SpriteRenderer>().flipY = true;
            weaponObj.GetComponent<SpriteRenderer>().flipX = true;
            modifier = 1;
        }
        else
        {
          //  angle = Mathf.Clamp(angle, -23, 15);
            playerAspect.transform.localScale = new Vector2(-1, 1);
            weaponObj.GetComponent<SpriteRenderer>().flipY = false;
            weaponObj.GetComponent<SpriteRenderer>().flipX = true;
            modifier = -1;
        }


        weaponObj.transform.eulerAngles = new Vector3(0,0,angle);
        weaponReloadTime -= Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (weaponReloadTime < 0)
            {
                if (gameManager.money < weapon.cost)
                    return;

                Transform cannon = weaponObj.transform.GetChild(0);

                for (int i = 0; i < weapon.bulletsnb; i++)
                {
                    GameObject bullet = Instantiate(weapon.Bullet, cannon.position + (new Vector3(0,-2f,0)*i*0), Quaternion.identity, transform.Find("Bullets"));
                    bullet.GetComponent<Rigidbody2D>().AddForce((cannon.position - transform.position) * 400 + (new Vector3(0,-400f,0)*(i+1)));
                    bullet.GetComponent<Bullet>().damage = weapon.damage;
                    bullet.GetComponent<Bullet>().knockdown = weapon.knockdown;
                    Destroy(bullet, 25f);
                }

                GetComponent<AudioSource>().PlayOneShot(weapon.weaponSound);

                weaponReloadTime = weapon.recoilTime;
                gameManager.money -= weapon.cost;
            }
        }


        if (rb.velocity.magnitude > 2.5f)
        legDelay = legDelay-(1* Mathf.RoundToInt(rb.velocity.magnitude/20));

        if (legDelay <= 0)
        {
            legDelay = 8;
            legId++;
            if (legId == 4)
                legId = 0;
        }

        legs.sprite = legsSpriteSheet.sprites[legId];
    }

    public void hit()
    {
        for (int i = 0; i < playerAspect.transform.childCount; i++)
        {
            if (playerAspect.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>())
            {
                playerAspect.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().DOKill();
                playerAspect.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                playerAspect.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f);
            }

        }

        playerAspect.GetComponent<AudioSource>().Play();
    }
}