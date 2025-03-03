using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DigGroundPart : MonoBehaviour
{
    Rigidbody[] rbs;
    Collider coll;

    private void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        coll = GetComponent<Collider>();
    }


    public void Dig()
    {
        coll.enabled = false;
        StartCoroutine(coro());
        IEnumerator coro()
        {
            foreach (Rigidbody rb in rbs)
            {
                rb.transform.SetParent(transform.parent);
                rb.isKinematic = false;
                rb.useGravity = true;
                rb.AddExplosionForce(150, rb.position, 50, Random.Range(.1f, 2f), ForceMode.Acceleration);
                rb.transform.DOScale(rb.transform.localScale*.8f, .2f);
            }
            transform.DOScale(Vector3.zero, .2f).OnComplete(() =>
            {
                coll.enabled = false;
            });

            yield return new WaitForSeconds(4f);
            foreach (Rigidbody rb in rbs)
            {
                yield return new WaitForSeconds(Random.Range(0f, 1f));
                rb.transform.DOScale(rb.transform.localScale*Random.Range(.15f,.5f), Random.Range(2f,5f)).SetEase(Ease.InBack, 1);
            }
        }
        
    }
}
