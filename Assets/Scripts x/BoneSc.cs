using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BoneSc : MonoBehaviour
{
    [HideInInspector] public MeshCollider coll;
    //Rigidbody rb;
    Renderer rend;
    public Color highlight; //Color emission;
    [HideInInspector] public BoneTextureSc texture;
    [HideInInspector] public int dustTotal;
    [HideInInspector] public Image ui;
    public enum BoneState { droped,dirty,clean,attached}

    public BoneState currentState;
    public BoneState collectingState = BoneState.dirty;

    Vector3 initScale = Vector3.one;

    private void Awake()
    {
        coll = GetComponent<MeshCollider>();
        //rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        //emission = rend.material.GetColor("_EmissionColor");

        texture = GetComponent<BoneTextureSc>();
    }
    private void Start()
    {
        dustTotal = GetDustCount();
        ui = BonesManager.instance.AddBone(this);

        if (collectingState == BoneState.clean)
        {
            rend.sharedMaterial = BonesManager.instance.bonePolishedMat;
        }

        initScale = transform.localScale;
    }
    public int GetDustCount()
    {
        return transform.GetChild(0).childCount;
    }
    public void Collect(Transform parent)
    {
        gameObject.tag = "Untagged";
        coll.enabled = false;
        transform.SetParent(parent);
        transform.DOLocalJump(Vector3.zero, 2f, 1, .6f);
        transform.DOScale(Vector3.zero,.75f).SetEase(Ease.InBack,1);

        SetHighlightState(true);
        currentState = collectingState;

        BonesManager.instance.UpdateState(this);
    }

    public void SetHighlightState(bool state)
    {
        if (state)
        {
            rend.material.SetColor("_EmissionColor", highlight);
        }
        else
        {
            rend.material.SetColor("_EmissionColor", Color.black);
        }
    }

    public void ToCleanPlace(Transform parent)
    {
        GameManager.instance.cleanPlace.boneInTable = this;
        coll.enabled = true;
        transform.SetParent(parent);
        transform.DOLocalMove(Vector3.zero, 1f);
        transform.DOLocalRotate(Vector3.zero, 1f);
        transform.DOScale(initScale*.6f, 1f);
        texture.Init();

        coll.convex = false;
    }
    public void ResetBoneToBackPack(Transform parent)
    {
        StartCoroutine(coro());
        IEnumerator coro()
        {
            transform.DOPunchScale(transform.localScale * .7f, .75f, 0);
            yield return new WaitForSeconds(.8f);
            coll.convex = true;
            coll.enabled = false;
            transform.SetParent(parent);
            transform.DOLocalMove(Vector3.zero, 1f);
            transform.DOLocalRotate(Vector3.zero, 1f);
            transform.DOScale(Vector3.zero, 1f);
            rend.sharedMaterial = BonesManager.instance.bonePolishedMat;

            currentState = BoneState.clean;
            BonesManager.instance.UpdateState(this);

            SetHighlightState(false);
        }
    }
}
