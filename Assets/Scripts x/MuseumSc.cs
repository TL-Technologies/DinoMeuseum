using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseumSc : MonoBehaviour
{
    public Transform doorPoint;
    public GameObject visitorObj;

    public static MuseumSc instance;
    private void Awake()
    {
        instance = this;
    }

    public void SpawnVisitor(Transform target)
    {
        Instantiate(visitorObj, doorPoint.position, Quaternion.identity).GetComponent<VisitorSc>().target = target;
    }
}
