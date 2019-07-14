using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float spawnDelay = 7f ;
    public float moneyInitialDelay = 15f;

    float delay ;
    float moneyDelay;

    public Transform[] spawnLocation;

    public int maxEnemies = 2;


    public GameObject enemyPrefab;

    public GameObject MoneyBagPrefab;

    public Transform moneySpawn;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        delay = 2f;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isActive == false)
            return;

        delay -= Time.deltaTime* (gameManager.difficulty);
        moneyDelay -= Time.deltaTime;

        maxEnemies = Mathf.RoundToInt(2 + gameManager.difficulty / 10f);

        if (delay <= 0)
        {
            delay = spawnDelay;

            for (int i = 0; i < Random.Range(1, maxEnemies); i++)
            {
                Instantiate(enemyPrefab, spawnLocation[Random.Range(0, spawnLocation.Length)].position, Quaternion.identity, transform);
            }
        }

        if (moneyDelay <= 0)
        {
            moneyDelay = moneyInitialDelay;

            Instantiate(MoneyBagPrefab, new Vector2(moneySpawn.position.x + Random.Range(-3, 3), moneySpawn.position.y + Random.Range(-3, 3)), Quaternion.identity, transform);
        }
    }
}
