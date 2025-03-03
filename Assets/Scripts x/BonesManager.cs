using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BonesManager : MonoBehaviour
{
    public Transform parent;
    public GameObject boneUIObj;
    public List<BoneSc> bones = new List<BoneSc>();
    public int bonesAttached = 0;
    public Sprite boneDirty, boneClean;

    public static BonesManager instance;

    public Material bonePolishedMat;

    private void Awake()
    {
        instance = this;
    }

    public Image AddBone(BoneSc bone)
    {
        bones.Add(bone);

        return(Instantiate(boneUIObj, parent).GetComponent<Image>());
    }

    void BoneDirty(Image bone)
    {
        bone.transform.DOPunchScale(Vector3.one*1.5f, .55f, 0);
        bone.sprite = boneDirty;
    }
    void BoneClean(Image bone)
    {
        bone.transform.DOPunchScale(Vector3.one*2, .65f, 0);
        bone.sprite = boneClean;
    }
    void BoneAttached(Image bone)
    {
        bone.transform.GetChild(0).DOScale(Vector3.one, .65f).SetEase(Ease.OutBack,3);

        bonesAttached++;
        //Debug.Log(bonesAttached + " - " + bones.Count);
        if (bonesAttached==bones.Count)
        {
            GameManager.instance.SkeletonComplete();
        }
    }

    public void UpdateState(BoneSc bone)
    {
        switch (bone.currentState)
        {
            case BoneSc.BoneState.droped:
                break;
            case BoneSc.BoneState.dirty:
                BoneDirty(bone.ui);
                break;
            case BoneSc.BoneState.clean:
                BoneClean(bone.ui);
                break;
            case BoneSc.BoneState.attached:
                BoneAttached(bone.ui);
                break;
        }
    }
}
