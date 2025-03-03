using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVisitor : MonoBehaviour
{
    private void Start()
    {
        if (Random.Range(0,3)!=0)
        {
            Invoke("Spawn", Random.Range(0f, 2f));
        }
    }
    void Spawn()
    {
        MuseumSc.instance.SpawnVisitor(transform);
    }
}
