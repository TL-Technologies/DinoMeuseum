using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuadUI : MonoBehaviour
{
    public Renderer bg;
    public Renderer icon;
    public TextMeshPro text;

    Color colorWhite,colorDark;
    float bgAlpha, iconAlpha;

    private void Start()
    {
        if (text != null) colorWhite = text.color;
        if (icon != null) colorWhite = icon.material.color;
        colorDark = bg.material.color;
        bgAlpha = bg.material.color.a;
    }
    public void Highlight(bool state)
    {
        if (state)
        {
            bg.material.color = new Color(colorWhite.r, colorWhite.g, colorWhite.b, bgAlpha);

            if (text != null) text.color = new Color(colorDark.r, colorDark.g, colorDark.b, 1);
            if (icon != null) icon.material.color = new Color(colorDark.r, colorDark.g, colorDark.b, 1);
        }
        else
        {
            bg.material.color = new Color(colorDark.r, colorDark.g, colorDark.b, bgAlpha);

            if (text != null) text.color = new Color(colorWhite.r, colorWhite.g, colorWhite.b, 1);
            if (icon != null) icon.material.color = new Color(colorWhite.r, colorWhite.g, colorWhite.b, 1);
        }
        
    }
}
