using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class deadScreen : MonoBehaviour
{

    public Text maxMoney;
    public Text killCount;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endScreen(GameManager gm)
    {
        gameObject.SetActive(true);
        maxMoney.text = Mathf.Round(gm.maxMoney).ToString() + " M$";
        killCount.text = gm.killCount.ToString();
    }

    public void Replay()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Link()
    {
        Application.OpenURL("https://raccoonlabs.fr");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
