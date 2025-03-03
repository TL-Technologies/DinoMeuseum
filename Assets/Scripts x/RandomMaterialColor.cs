using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterialColor : MonoBehaviour
{
    public int mat;
    
    private void Start()
    {
        GetComponent<Renderer>().materials[mat].color = GameManager.instance.clothGradiant.Evaluate(Random.Range(0f, 1f));
    }
}
