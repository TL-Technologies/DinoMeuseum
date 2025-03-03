using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DustPart : MonoBehaviour
{
    Rigidbody[] rbs;
    Collider coll;

    private void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        coll = GetComponent<Collider>();
    }


    public void Destroy()
    {
        coll.enabled = false;
        StartCoroutine(coro());
        IEnumerator coro()
        {
            foreach (Rigidbody rb in rbs)
            {
                rb.transform.SetParent(null);
                rb.isKinematic = false;
                rb.useGravity = true;
                rb.AddExplosionForce(Random.Range(20,140), rb.position, 30, Random.Range(.1f, 2f), ForceMode.Acceleration);
                //rb.transform.DOScale(rb.transform.localScale * .8f, .2f);
            }

            transform.SetParent(null);

            GameManager.instance.cleanPlace.CheckCLeaning();


            yield return new WaitForSeconds(4f);
            foreach (Rigidbody rb in rbs)
            {
                yield return new WaitForSeconds(Random.Range(0f, 1f));
                rb.transform.DOScale(Vector3.zero, Random.Range(2f, 5f)).SetEase(Ease.InBack, 1).OnComplete(()=>Destroy(rb.gameObject,.2f));
            }

            

            Destroy(gameObject, .1f);
        }

    }
}
