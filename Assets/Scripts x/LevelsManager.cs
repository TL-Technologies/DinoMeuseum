using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelsManager : MonoBehaviour
{
    public List<GameObject> levels = new List<GameObject>();

    public TextMeshProUGUI leveltxt;


    private void Awake()
    {

        if (PlayerPrefs.GetInt("FirstTime") == 0)
        {
            PlayerPrefs.SetInt("FirstTime", 1);
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.SetInt("prevLevel", -1);
            PlayerPrefs.SetInt("DigLevel", 1);
            PlayerPrefs.SetInt("SpeedLevel", 1);
            PlayerPrefs.SetInt("CleanLevel", 1);
        }


        //LEVEL
        int spawn = 0;

        if (PlayerPrefs.GetInt("prevLevel") == -1)
        {
            if (PlayerPrefs.GetInt("Level") <= levels.Count) spawn = PlayerPrefs.GetInt("Level") - 1;
            else spawn = Random.Range(0, levels.Count);

            PlayerPrefs.SetInt("prevLevel", spawn);
        }
        else spawn = PlayerPrefs.GetInt("prevLevel");



        Instantiate(levels[spawn]);

        leveltxt.text = "LEVEL " + PlayerPrefs.GetInt("Level").ToString("00");
    }
}
