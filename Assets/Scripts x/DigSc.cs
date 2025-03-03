using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigSc : MonoBehaviour
{
    public Animator anim;
    public List<DigGroundPart> digGrounds = new List<DigGroundPart>();
    public SkinnedMeshRenderer axe;


    void UpdateLevel()
    {
        
    }
    public void SetDigValues(float digSize, float axeSize)
    {
        transform.localScale = Vector3.one * digSize;
        axe.SetBlendShapeWeight(0, axeSize);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dig"))
        {
            AddGround(other.GetComponent<DigGroundPart>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Dig"))
        {
            RemoveGround(other.GetComponent<DigGroundPart>());
        }
    }

    public void AddGround(DigGroundPart ground)
    {
        digGrounds.Add(ground);
        anim.SetBool("Digging", true);
    }
    public void RemoveGround(DigGroundPart dig)
    {
        digGrounds.Remove(dig);
        if (digGrounds.Count == 0) anim.SetBool("Digging", false);
    }
}
