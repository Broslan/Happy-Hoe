using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuBtns : MonoBehaviour
{
    [SerializeField] GameObject firstCanvas;
    [SerializeField] GameObject optionsCanvas;
    [SerializeField] GameObject privacyPolycyCanvas;
    [SerializeField] GameObject shopCanvas;
    [SerializeField] Image soundBtn;
    [SerializeField] Sprite soundOnImg;
    [SerializeField] Sprite soundOffImg;
    public bool SoundStatus = true;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SoundSetting"))
        {
            PlayerPrefs.SetInt("SoundSetting", 1);
        }

        SoundStatus = PlayerPrefs.GetInt("SoundSetting") == 1;
        if (SoundStatus)
        {
            soundBtn.sprite = soundOnImg;
        }
        else
        {
            soundBtn.sprite = soundOffImg;
        }
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoOptions()
    {
        firstCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }

    public void OptionGoBack()
    {
        firstCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
    }
    
    public void PushSound()
    {
        SoundStatus = !SoundStatus;
        
        if (SoundStatus)
        {
            soundBtn.sprite = soundOnImg;
            PlayerPrefs.SetInt("SoundSetting", 1);
        }
        else
        {
            soundBtn.sprite = soundOffImg;
            PlayerPrefs.SetInt("SoundSetting", 0);
        }
    }

    public void GoPolycy()
    {
        optionsCanvas.SetActive(false);
        privacyPolycyCanvas.SetActive(true);
    }

    public void PolycyGoBack()
    {
        optionsCanvas.SetActive(true);
        privacyPolycyCanvas.SetActive(false);
    }

    public void GoShop()
    {
        shopCanvas.SetActive(true);
        firstCanvas.SetActive(false);
    }
    public void ShopGoBack()
    {
        shopCanvas.SetActive(false);
        firstCanvas.SetActive(true);
    }

    public void DeletaAll()
    {
        PlayerPrefs.DeleteAll();
    }
}
