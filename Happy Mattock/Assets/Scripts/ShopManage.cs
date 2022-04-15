using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManage : MonoBehaviour
{
    [SerializeField] GameObject[] buttonEquiped;
    [SerializeField] GameObject[] buttonEquip;
    [SerializeField] GameObject[] buttonBuy; //only 2
    [SerializeField] TextMeshProUGUI coinsTxt;
    int isEquiped;
    int money = 50;
    const int GOLDENCOST = 50;
    const int DIMONDCOST = 150;


    private void Awake()
    {

        if (!PlayerPrefs.HasKey("Bought1"))
        {
            PlayerPrefs.SetInt("Bought1", 0);
        }
        if (!PlayerPrefs.HasKey("Bought2"))
        {
            PlayerPrefs.SetInt("Bought2", 0);
        }
        if (!PlayerPrefs.HasKey("money"))
        {
            PlayerPrefs.SetInt("money", 50);
        }

        money = PlayerPrefs.GetInt("money");

        coinsTxt.text = money.ToString();

        if (PlayerPrefs.GetInt("Bought1") == 1)
        {
            buttonBuy[0].SetActive(false);
            buttonEquip[1].SetActive(true);
        }

        if (PlayerPrefs.GetInt("Bought2") == 1)
        {
            buttonBuy[1].SetActive(false);
            buttonEquip[2].SetActive(true);
        }

        isEquiped = PlayerPrefs.GetInt("isEquipped");

        switch (isEquiped)
        {
            case 0:
                break;
            case 1:
                buttonEquiped[0].SetActive(false);
                buttonEquip[0].SetActive(true);
                buttonEquiped[1].SetActive(true);
                buttonEquip[1].SetActive(false);
                break;
            case 2:
                buttonEquiped[0].SetActive(false);
                buttonEquip[0].SetActive(true);
                buttonEquiped[2].SetActive(true);
                buttonEquip[2].SetActive(false);
                break;
            default:
                break;
        }
    }

    public void PushEquip(int hoeNumber)
    {
        buttonEquiped[hoeNumber].SetActive(true);
        buttonEquip[hoeNumber].SetActive(false);
        buttonEquiped[isEquiped].SetActive(false);
        buttonEquip[isEquiped].SetActive(true);
        isEquiped = hoeNumber;
        PlayerPrefs.SetInt("isEquipped", isEquiped);
    }

    public void PushBuy(int hoeNumber)
    {
        switch (hoeNumber)
        {
            case 1:
                if(money >= GOLDENCOST)
                {
                    buttonBuy[0].SetActive(false);
                    buttonEquip[1].SetActive(true);
                    PlayerPrefs.SetInt("Bought1", 1);
                    money -= GOLDENCOST;
                    coinsTxt.text = money.ToString();
                    PlayerPrefs.SetInt("money", money);
                }
                break;
            case 2:
                if (money >= DIMONDCOST)
                {
                    buttonBuy[1].SetActive(false);
                    buttonEquip[2].SetActive(true);
                    PlayerPrefs.SetInt("Bought2", 1);
                    money -= DIMONDCOST;
                    coinsTxt.text = money.ToString();
                    PlayerPrefs.SetInt("money", money);
                }
                break;
            default:
                break;
        }
    }
}
