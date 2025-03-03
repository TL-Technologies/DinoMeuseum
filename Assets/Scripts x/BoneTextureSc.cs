using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneTextureSc : MonoBehaviour
{
    [HideInInspector] public Material mat;
    MeshRenderer rend;
    [HideInInspector] public Texture2D dirtMaskTexture;
    public Texture2D dirtMaskTextureBase;
    public Material polishMat;


    private void Awake()
    {
        rend = GetComponent<MeshRenderer>();
    }


    public void Init()
    {
        transform.GetChild(0).gameObject.SetActive(true);

        rend.sharedMaterial = polishMat;

        dirtMaskTexture = new Texture2D(dirtMaskTextureBase.width, dirtMaskTextureBase.height);
        dirtMaskTexture.SetPixels(dirtMaskTextureBase.GetPixels());
        dirtMaskTexture.Apply();

        mat = rend.material;
        mat.SetTexture("_dirtMask", dirtMaskTexture);



        //
        /*dirtAmountTotal = 0f;
        for (int x = 0; x < dirtMaskTextureBase.width; x++)
        {
            for (int y = 0; y < dirtMaskTextureBase.height; y++)
            {
                dirtAmountTotal += dirtMaskTextureBase.GetPixel(x, y).g;
            }
        }
        dirtAmount = dirtAmountTotal;*/

    }

    public void PaintAll()
    {
        for (int y = 0; y < dirtMaskTexture.height; y++)
        {
            for (int x = 0; x < dirtMaskTexture.width; x++)
            {
                dirtMaskTexture.SetPixel(
                x,
                y,
                Color.black);
            }
        }
        dirtMaskTexture.Apply();
    }

    public float GetBlackAmount()
    {
        Color[] colors = dirtMaskTexture.GetPixels();
        float blackColors = 0;
        foreach (Color c in colors)
        {
            if (c.Equals(Color.black))
            {
                blackColors++;
            }
        }
        return (blackColors / colors.Length);
        //Debug.Log($"total {colors.Length} / black {blackColors} amount: {blackColors/colors.Length}");
    }
}
