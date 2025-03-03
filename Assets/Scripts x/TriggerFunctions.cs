using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFunctions : MonoBehaviour
{
    [HideInInspector] public bool inCleanPlace = false;

    public static TriggerFunctions instance;
    [HideInInspector] public bool inUpgrade;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (inCleanPlace) GameManager.instance.ToCleanPos();
            if (inUpgrade)
            {
                GameManager.instance.upgradeSystem.UpgradePanelState(true);
                inUpgrade = false;
                GameManager.instance.upgradeSystem.quadUI.Highlight(false);
            }
        }
    }


}
