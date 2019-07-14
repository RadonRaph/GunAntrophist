using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    public float money;

    public Slider moneySlider;

    public int killCount = 0;

    public float difficulty;

    public float maxMoney;

    public deadScreen deadScreen;

    public bool isActive = true;

    public GameObject pauseMenu;
    public bool ended = false;

    public Text moneyText;

    public Text killCountText;
    // Start is called before the first frame update
    void Start()
    {
        money = 250;
        maxMoney = money;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isActive = !isActive;
        }


        if (isActive == false && ended == false)
        {

            pauseMenu.SetActive(true);
            return;
        }
        else
        {
            pauseMenu.SetActive(false);
        }

        difficulty = (killCount / 10f)+1;

        if (money > moneySlider.maxValue)
        {
            moneySlider.maxValue = money;
            maxMoney = money;
        }

        moneyText.DOText("$ " + Mathf.Round(money).ToString(), 0.05f);
        killCountText.DOText(killCount.ToString(), 0.1f);

        moneySlider.DOValue(money, 0.3f);

        if (money < 0.01*maxMoney)
        {
            pauseMenu.SetActive(false);
            ended = true;
            //Destroy(pauseMenu);
            deadScreen.endScreen(this);
            isActive = false;
        }
    }

    public void UnPause()
    {
        isActive = true;
    }
}
