using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanPlace : MonoBehaviour
{
    public QuadUI quadUI;
    public Transform camPos,bonePos;
    [HideInInspector] public BoneSc boneInTable;
    public Transform playerWaitPos;

    public Transform rotatingBone;


    //just for help
    public QuadUI upgradeQuadUI;

    private void Start()
    {
        GameManager.instance.rotateBone.bone = rotatingBone;
        GameManager.instance.cleanPlace = this;

        GameManager.instance.upgradeSystem.quadUI = upgradeQuadUI;
    }

    public void Enter()
    {
        quadUI.Highlight(false);
    }

    public void CheckCLeaning()
    {
        float t = boneInTable.GetDustCount();
        GameManager.instance.SetPercentProgress((((boneInTable.dustTotal-t) / boneInTable.dustTotal)*100).ToString("00") + "%\nCLEAN");
        if (t==0)
        {
            GameManager.instance.SetPercentProgress("CLEANED");
            GameManager.instance.ToPolishing();
        }
    }
    public void CheckPolishing()
    {
        float t = boneInTable.texture.GetBlackAmount();

        GameManager.instance.SetPercentProgress(((t+.2f)*100).ToString("00")+"%\nPOLISH");

        //Debug.Log("%  " + t);
        if (t>.8f)
        {
            GameManager.instance.SetPercentProgress("POLISHED");
            boneInTable.texture.PaintAll();
            NextBone();
        }
    }

    public void NextBone()
    {
        GameManager.instance.polish.working = false;
        StartCoroutine(coro());
        IEnumerator coro()
        {
            GameManager.instance.player.BoneCleaned(boneInTable);

            boneInTable.ResetBoneToBackPack(GameManager.instance.player.backPack.transform);

            yield return new WaitForSeconds(1f);

            boneInTable = null;
            GameManager.instance.ToCleaning();

            if (GameManager.instance.player.dirtyBones.Count > 0)
            {
                GameManager.instance.player.GetBoneToCleaning();
            }
            else
            {
                GameManager.instance.ToIdlePos();
            }
        }
    }
}
