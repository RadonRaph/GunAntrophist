using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitManager : MonoBehaviour
{

    public Outfit[] outfit;

    public SpriteRenderer skin;
    public SpriteRenderer shirt;
    public SpriteRenderer legs;

    public Enemy enemy;
    Sprite[] sprites;
    SpriteSheet legsSpriteSheet;

    int legId = 0;

    float legDelay = 8;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        sprites = outfit[Random.Range(0, outfit.Length)].GenerateOutfit();
    }

    void Update()
    {
        if (enemy.EnemyMode == Enemy.mode.zombie)
        {
            skin.sprite = sprites[1];
            shirt.sprite = sprites[3];
        }
        else
        {
            skin.sprite = sprites[0];
            shirt.sprite = sprites[2];
        }

        legsSpriteSheet = ScriptableObject.CreateInstance("SpriteSheet") as SpriteSheet;
        legsSpriteSheet.sprites = new Sprite[3]{sprites[4], sprites[5], sprites[6]};

        legDelay--;
        if (legDelay <= 0)
        {
            legDelay = 8;
            legId++;
            if (legId == 3)
                legId = 0;
        }

        legs.sprite = legsSpriteSheet.sprites[legId];
    }
}
