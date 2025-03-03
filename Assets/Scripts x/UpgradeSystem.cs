using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    public TextMeshProUGUI digLvlTxt,digCoins;
    int digCost;
    public Button digBtn;
    public int digLevel = 1;
    public AnimationCurve digSizeCurve; int maxDigSize;
    public AnimationCurve axeSizeCurve;

    public TextMeshProUGUI speedLvlTxt, speedCoins;
    int speedCost;
    public Button speedBtn;
    public int speedLevel = 1;
    public AnimationCurve speedCurve; int maxSpeedCurve;

    public TextMeshProUGUI cleanLvlTxt, cleanCoins;
    int cleanCost;
    public Button cleanBtn;
    public int cleanLevel = 1;
    public AnimationCurve cleanCurve; int maxCleanCurve;

    public Transform panel;

    public QuadUI quadUI;

    private void Start()
    {
        maxCleanCurve = (int)cleanCurve.keys[cleanCurve.keys.Length - 1].time;
        maxSpeedCurve = (int)speedCurve.keys[speedCurve.keys.Length - 1].time;
        maxDigSize = (int)digSizeCurve.keys[digSizeCurve.keys.Length - 1].time;


        UpdateDigLevel();
        UpdateSpeedLevel();
        UpdateCleanLevel();


    }



    //DIG
    void UpdateDigLevel()
    {
        digLevel = PlayerPrefs.GetInt("DigLevel");
        digLvlTxt.text = digLevel.ToString("00");
        digCost = (int)(60 + (digLevel - 1) * 1.2f * 60);
        digCoins.text = digCost.ToString();

        CheckDigBtn();


        GameManager.instance.player.dig.SetDigValues(digSizeCurve.Evaluate(digLevel), axeSizeCurve.Evaluate(digLevel));
    }
    public void UpgradeDig()
    {
        if (digCost <= GameManager.instance.coins)
        {
            GameManager.instance.coins -= digCost;
            PlayerPrefs.SetInt("DigLevel", (digLevel + 1));
            UpdateDigLevel();
        }
        
    }
    void CheckDigBtn()
    {
        if (digLevel >= maxDigSize)
        {
            digCoins.text = "MAX";
            digBtn.interactable = false;
        }
    }

    //SPEED
    void UpdateSpeedLevel()
    {
        speedLevel = PlayerPrefs.GetInt("SpeedLevel");
        speedLvlTxt.text = speedLevel.ToString("00");
        speedCost = ((int)(60 + (speedLevel - 1) * 1.2f * 60));
        speedCoins.text = speedCost.ToString();

        CheckSpeedBtn();

        GameManager.instance.player.controller.speed = speedCurve.Evaluate(speedLevel);
    }
    public void UpgradeSpeed()
    {
        if (speedCost <= GameManager.instance.coins)
        {
            GameManager.instance.coins -= speedCost;
            PlayerPrefs.SetInt("SpeedLevel", (speedLevel + 1));
            UpdateSpeedLevel();
        }
        
    }
    void CheckSpeedBtn()
    {
        if (speedLevel >= maxSpeedCurve)
        {
            speedCoins.text = "MAX";
            speedBtn.interactable = false;
        }
    }

    //CLEAN
    void UpdateCleanLevel()
    {
        cleanLevel = PlayerPrefs.GetInt("CleanLevel");
        cleanLvlTxt.text = cleanLevel.ToString("00");
        cleanCost = ((int)(60 + (cleanLevel - 1) * 1.2f * 60));
        cleanCoins.text = cleanCost.ToString();

        CheckCleanBtn();

        GameManager.instance.polish.size =  (int)cleanCurve.Evaluate(cleanLevel);
    }
    public void UpgradeClean()
    {
        if (cleanCost <= GameManager.instance.coins)
        {
            GameManager.instance.coins -= cleanCost;
            PlayerPrefs.SetInt("CleanLevel", (cleanLevel + 1));
            UpdateCleanLevel();
        }

        
    }
    void CheckCleanBtn()
    {
        if (cleanLevel >= maxCleanCurve)
        {
            cleanCoins.text = "MAX";
            cleanBtn.interactable = false;
        }
    }




    public void UpgradePanelState(bool state)
    {
        if (state)
        {
            panel.DOScale(Vector3.one, .25f).SetEase(Ease.OutBack,3);
            GameManager.instance.player.transform.DORotate(Vector3.up * -180f, .3f);
            GameManager.instance.player.transform.DOMove(quadUI.transform.position, .3f);
        }
        else
        {
            panel.DOScale(Vector3.zero, .25f).SetEase(Ease.InBack,2);
        }

        GameManager.instance.camAnim.SetBool("Upgrade", state);
    }
}
