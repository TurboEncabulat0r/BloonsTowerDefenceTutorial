using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UImanager : MonoBehaviour
{
    public static UImanager instance;
    
    public TMP_Text moneyText;
    public TMP_Text livesText;
    public TMP_Text roundText;

    public GameObject towerMenu;
    public GameObject upgradeMenu;


    private Monkey selectedMonkey;
    
    
    
    public void sellSelectedMonkey()
    {
        GameManager.instance.money += selectedMonkey.cost / 2;
        Destroy(selectedMonkey.gameObject);
        deselectMonkey();
    }
    
    public void selectMonkey(Monkey m)
    {
        selectedMonkey = m;
        towerMenu.SetActive(false);
        upgradeMenu.SetActive(true);
    }

    public void deselectMonkey()
    {
        towerMenu.SetActive(true);
        upgradeMenu.SetActive(false);
    }

    public void updateTextUi()
    {
        livesText.text = "Lives: " +  GameManager.instance.lives;
        moneyText.text = "Cash: " +  GameManager.instance.money;
        roundText.text = "Round: " +  GameManager.instance.currentRound;
    }

    private void Update()
    {
        updateTextUi();
    }

    private void Awake()
    {
        instance = this;
    }
}
