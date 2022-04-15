using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int gameScore = 0;
    public int recordGameScore = 0;
    public int wheatCombo;
    public int carrotCombo;
    public int money;
    [SerializeField] PrefabHolder prefabHolder;
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] Image[] pigImgs;
    [SerializeField] Image[] cowImgs;
    [SerializeField] private GameObject m_UICanvase;
    [SerializeField] private GameObject m_GameOverCanvase;
    [SerializeField] private GameObject m_NewRecordName;
    [SerializeField] private GameObject m_RecordName;
    [SerializeField] private GameObject m_RecordScore;
    [SerializeField] private TextMeshProUGUI m_ScoreTxt;
    [SerializeField] private TextMeshProUGUI m_RecordScoreTxt;

    private void Awake()
    {
        recordGameScore = PlayerPrefs.GetInt("RecordScore");
        money = PlayerPrefs.GetInt("money");
    }

    public void AddItemToCombo(int itemType)
    {
        if(itemType == 1)
        {
            AddScore(5);
            if (carrotCombo < 3)
            {
                SetImg(pigImgs, carrotCombo, true);
                carrotCombo++;
            }
        }

        if (itemType == 2)
        {
            AddScore(5);
            textMesh.text = gameScore.ToString();
            if (wheatCombo < 3)
            {
                SetImg(cowImgs, wheatCombo, true);
                wheatCombo++;
            }
        }

        if (carrotCombo == 3 && wheatCombo == 3)
        {
            carrotCombo = 0;
            wheatCombo = 0;
            ImgToZero();
            AddScore(50);
        }

    }

    private void ImgToZero()
    {
        SetImg(cowImgs, 0, false);
        SetImg(cowImgs, 1, false);
        SetImg(cowImgs, 2, false);
        SetImg(pigImgs, 0, false);
        SetImg(pigImgs, 1, false);
        SetImg(pigImgs, 2, false);
    }

    private void SetImg(Image[] images, int imageNumber, bool imageStatus)
    {
        if (imageStatus)
        {
            images[imageNumber].sprite = prefabHolder.green_Button;
        }
        else
        {
            images[imageNumber].sprite = prefabHolder.red_Button;
        }
    }

    private void AddScore(int score)
    {
        gameScore += score;
        textMesh.text = gameScore.ToString();
    }

    public void SetFinaleScore() 
    {
        m_UICanvase.SetActive(false);
        m_GameOverCanvase.SetActive(true);
        if (gameScore > recordGameScore)
        {
            recordGameScore = gameScore;
            PlayerPrefs.SetInt("RecordScore", recordGameScore);
            m_NewRecordName.SetActive(true);
            m_ScoreTxt.text = recordGameScore.ToString();
        }
        else
        {
            m_RecordName.SetActive(true);
            m_RecordScore.SetActive(true);
            m_ScoreTxt.text = gameScore.ToString();
            m_RecordScoreTxt.text = recordGameScore.ToString();
        }
        money += gameScore / 10;
        PlayerPrefs.SetInt("money", money);
    }
}
