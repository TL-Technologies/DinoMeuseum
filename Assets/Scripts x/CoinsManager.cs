using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinsManager : MonoBehaviour
{
    public GameObject coin;
    public float force;

    public Transform coinsCollectPos;

    public static CoinsManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void SpawnCoins(int count,Vector3 spawnPos)
    {
        List<CoinSc> coinsSpawned = new List<CoinSc>();

        StartCoroutine(coro());
        IEnumerator coro()
        {
            for (int i = 0; i < count; i++)
            {
                CoinSc c = Instantiate(coin, spawnPos, Quaternion.identity).GetComponent<CoinSc>();
                c.rb.AddForce(new Vector3(Random.Range(-.15f, .15f), 1, Random.Range(-.15f, .15f)) * force, ForceMode.Acceleration);
                c.rb.AddTorque(new Vector3(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180)) * 4000, ForceMode.Acceleration);
                yield return new WaitForEndOfFrame();

                coinsSpawned.Add(c);
            }
            yield return new WaitForSeconds(.5f);
            GameManager.instance.coinsTxt.transform.parent.gameObject.SetActive(true);
            foreach (CoinSc c in coinsSpawned)
            {
                c.transform.SetParent(coinsCollectPos);
                float t = Random.Range(.3f, .8f);
                c.transform.DOLocalMove(Vector3.zero, t).OnComplete(() => GameManager.instance.coins++);
                c.transform.DOScale(Vector3.zero, t).SetEase(Ease.InBack);
                yield return new WaitForEndOfFrame();
            }

            GameManager.instance.Won();
        }
    }

}
