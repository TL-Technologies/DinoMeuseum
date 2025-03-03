using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public PlayerSc player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bone"))
        {
            player.CollectBone(other.GetComponent<BoneSc>());
        }
        if (other.CompareTag("Skeleton"))
        {
            if (player.cleanedBones.Count>0)
            {
                player.AssignBones(other.GetComponent<SkeletonSc>());
            }
        }
        if (other.CompareTag("CleanPlace"))
        {
            TriggerFunctions.instance.inCleanPlace = true;
            GameManager.instance.cleanPlace.quadUI.Highlight(true);
        }
        if (other.CompareTag("Upgrade"))
        {
            TriggerFunctions.instance.inUpgrade = true;
            GameManager.instance.upgradeSystem.quadUI.Highlight(true);
        }
        if (other.CompareTag("Coin"))
        {
            player.CollectCoin(other.GetComponent<CoinSc>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Skeleton"))
        {
            //player.StopAssign();
        }
        if (other.CompareTag("CleanPlace"))
        {
            TriggerFunctions.instance.inCleanPlace = false;
            GameManager.instance.cleanPlace.quadUI.Highlight(false);
        }
        if (other.CompareTag("Upgrade"))
        {
            TriggerFunctions.instance.inUpgrade = false;
            GameManager.instance.upgradeSystem.quadUI.Highlight(false);
        }
    }

    
}
