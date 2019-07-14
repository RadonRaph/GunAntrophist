using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{

    public GameObject Bullet;
    public Sprite weaponSprite;

    public int bulletsnb;

    public float damage;
    public float cost;
    public float recoilTime;
    public float range;
    public float knockdown;

    public AudioClip weaponSound;
}
