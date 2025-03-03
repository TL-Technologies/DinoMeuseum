using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SkeletonSc : MonoBehaviour
{

    private void Start()
    {
        GameManager.instance.skeleton = this;
    }

    public Transform AssignBone(BoneSc bone)
    {
        Transform pair = GetPair(bone.gameObject);
        if (pair==null) return null;

        bone.SetHighlightState(true);

        bone.transform.SetParent(pair.parent);
        bone.transform.DOScale(pair.localScale,.8f).SetEase(Ease.OutBack,7);
        bone.transform.DORotate(pair.eulerAngles,.4f);
        bone.transform.DOMove(pair.position, .5f).OnComplete(() => {
            bone.SetHighlightState(false);
            pair.gameObject.SetActive(false);
        });


        return pair;
    }

    Transform GetPair(GameObject bone)
    {
        foreach (Transform item in transform)
        {
            if (bone.name.Equals(item.gameObject.name))
            {
                return item;
            }
        }
        return null;
    }

    
    public void ToMusuem()
    {
        StartCoroutine(coro());
        IEnumerator coro()
        {
            transform.DOScale(Vector3.zero, .3f);
            yield return new WaitForSeconds(.3f);


            GameManager.instance.camFollow.following = transform;
            transform.SetParent(GameManager.instance.posMusuemSkeleton);
            transform.DOLocalMove(Vector3.zero, .7f);
            transform.DOLocalRotate(Vector3.zero, .5f);

            yield return new WaitForSeconds(.7f);

            GameManager.instance.posMusuemSkeleton.GetChild(0).gameObject.SetActive(true);

            transform.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack,4);

            yield return new WaitForSeconds(.7f);

            CoinsManager.instance.SpawnCoins(60, transform.position);
        }
    }
}
