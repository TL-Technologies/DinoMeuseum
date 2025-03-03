using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerSc : MonoBehaviour
{

    public SkinnedMeshRenderer backPack;

    public List<BoneSc> collectedBones = new List<BoneSc>();
    public List<BoneSc> dirtyBones = new List<BoneSc>();
    public List<BoneSc> cleanedBones = new List<BoneSc>();
    public PlayerController controller;
    public Color backpackHughlightColor;
    public Transform coinsCollection;

    public DigSc dig;

    public Animator anim;
    public void AssignBones(SkeletonSc skeleton)
    {
        List<BoneSc> _bones = new List<BoneSc>();
        _bones.AddRange(cleanedBones);

        StartCoroutine(coro());
        IEnumerator coro()
        {
            float smoothCam = GameManager.instance.camFollow.smoothFactor;
            GameManager.instance.camFollow.smoothFactor = .5f;
            foreach (BoneSc bone in _bones)
            {
                Transform bonePos = skeleton.AssignBone(bone);
                
                collectedBones.Remove(bone);
                cleanedBones.Remove(bone);

                UpdateBackPackSize();

                bone.currentState = BoneSc.BoneState.attached;
                BonesManager.instance.UpdateState(bone);

                GameManager.instance.camFollow.following = bonePos;

                yield return new WaitForSeconds(.35f);
            }
            
            GameManager.instance.camFollow.following = transform;
            yield return new WaitForSeconds(.2f);
            GameManager.instance.camFollow.smoothFactor = smoothCam;
        }

        
    }

    void DigGround()
    {
        List<DigGroundPart> _digGrounds = new List<DigGroundPart>();
        _digGrounds.AddRange(dig.digGrounds);

        foreach (DigGroundPart digGround in _digGrounds)
        {
            digGround.Dig();
            dig.digGrounds.Remove(digGround);
        }
        if (dig.digGrounds.Count == 0) anim.SetBool("Digging", false);
    }

    public void CollectBone(BoneSc bone)
    {
        bone.Collect(backPack.transform);
        
        collectedBones.Add(bone);

        if (bone.currentState==BoneSc.BoneState.dirty)
        {
            dirtyBones.Add(bone);
        }
        else
        {
            cleanedBones.Add(bone);
        }

        Invoke("UpdateBackPackSize", .5f);

        
    }
    void UpdateBackPackSize()
    {
        backPack.SetBlendShapeWeight(0, collectedBones.Count * 35);

        backPack.material.SetColor("_EmissionColor", backpackHughlightColor);
        backPack.transform.DOComplete();
        backPack.transform.DOPunchScale(backPack.transform.localScale * .7f, .4f,0).OnComplete(()=> backPack.material.SetColor("_EmissionColor", Color.black));
    }

    public void GetBoneToCleaning()
    {
        if (dirtyBones.Count == 0) return;

        dirtyBones[0].ToCleanPlace(GameManager.instance.cleanPlace.bonePos);
    }

    public void BoneCleaned(BoneSc bone)
    {
        dirtyBones.Remove(bone);
        cleanedBones.Add(bone);
    }

    public void CollectCoin(CoinSc coin)
    {
        coin.coll.enabled = false;
        coin.rb.isKinematic = true;
        coin.rb.useGravity = false;
        coin.gameObject.tag = "Untagged";
        coin.transform.SetParent(coinsCollection);
        coin.transform.DOLocalJump(Vector3.zero, 2, 1, .4f);
        coin.transform.DOScale(Vector3.zero, .4f).SetEase(Ease.InBack,6);
    }
}
