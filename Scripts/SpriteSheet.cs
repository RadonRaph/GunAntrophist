using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteSheet", menuName = "SpriteSheet")]
public class SpriteSheet : ScriptableObject
{
    public Sprite[] sprites;

    float delay;
    int spriteId =0;

    public SpriteSheet(Sprite[] _sprites)
    {
        sprites = _sprites;
    }
    /*
    public Sprite animate()
    {
        Sprite res;
        

        return res;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.1f);
        spriteId++;
    }*/
}
