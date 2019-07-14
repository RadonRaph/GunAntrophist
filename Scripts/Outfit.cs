using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Outfit", menuName = "Outfit")]
public class Outfit : ScriptableObject
{
    public Sprite skinNormal;
    public Sprite skinZombie;

    public Sprite[] teeShirtNormal;
    public Sprite[] teeShirtZombie;

    public SpriteSheet[] legs;

    

    public Sprite[] GenerateOutfit()
    {
        Sprite[] res = new Sprite[7];

        res[0] = skinNormal;
        res[1] = skinZombie;
        int idT = Random.Range(0, teeShirtNormal.Length);
        res[2] = teeShirtNormal[idT];
        res[3] = teeShirtZombie[idT];
        int id = Random.Range(0, legs.Length);
        res[4] = legs[id].sprites[0];
        res[5] = legs[id].sprites[1];
        res[6] = legs[id].sprites[2];


        return res;
    }

}
