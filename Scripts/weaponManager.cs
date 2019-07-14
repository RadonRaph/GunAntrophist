using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponManager : MonoBehaviour
{

    public Weapon[] weapons;

    public int weaponID;

    Player player;

    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        
        weaponID = 0;
        updateWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.magnitude > 0.5)
        {
            weaponID++;
            if (weaponID >= weapons.Length)
                weaponID = 0;

            updateWeapon();
        }
            
    }

    void updateWeapon()
    {
        player.weapon = weapons[weaponID];
        player.weaponObj.GetComponent<SpriteRenderer>().sprite = weapons[weaponID].weaponSprite;
        img.sprite = weapons[weaponID].weaponSprite;
    }
}
