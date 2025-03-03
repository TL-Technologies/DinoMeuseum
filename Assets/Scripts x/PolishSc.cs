using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolishSc : MonoBehaviour
{
    public bool working = false;

    public LayerMask layer;
    [HideInInspector] public BoneTextureSc currentBone;

    public Texture2D dirtBrush;

    public Rigidbody tool;

    [HideInInspector] public Vector3 initPos, initUp;
    public float toolSpeed = 1;
    Vector3 pos;

    int waitToCheck = 0;

    public int size=32;

    private void Start()
    {
        GameManager.instance.polish = this;
        initPos = tool.position;
        initUp = tool.transform.up;
        pos = initPos;
    }


    private void Update()
    {
        if (!working) return;

        ///
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit, 100.0f, layer))
            {
                pos = raycastHit.point;
                tool.transform.up = Vector3.Lerp(tool.transform.up, (raycastHit.transform.position - pos).normalized, 10 * Time.deltaTime);
                if (Vector3.Distance(tool.transform.position, pos) < .3f)
                {
                    Vector2 textureCoord = raycastHit.textureCoord;

                    int pixelX = (int)(textureCoord.x * currentBone.dirtMaskTexture.width);
                    int pixelY = (int)(textureCoord.y * currentBone.dirtMaskTexture.height);

                    //Vector2Int paintPixelPosition = new Vector2Int(pixelX, pixelY);
                    //Debug.Log("obj:  "+ raycastHit.transform.gameObject.name +  "UV: " + textureCoord + "; Pixels: " + paintPixelPosition);


                    /*int paintPixelDistance = Mathf.Abs(paintPixelPosition.x - lastPaintPixelPosition.x) + Mathf.Abs(paintPixelPosition.y - lastPaintPixelPosition.y);
                    int maxPaintDistance = 7;
                    if (paintPixelDistance < maxPaintDistance)
                    {
                        // Painting too close to last position
                        return;
                    }
                    lastPaintPixelPosition = paintPixelPosition;*/

                    // Paint Square in Dirt Mask
                    //int squareSize = 32;
                    int pixelXOffset = pixelX - (size / 2);
                    int pixelYOffset = pixelY - (size / 2);


                    for (int y = 0; y < size; y++)
                    {
                        for (int x = 0; x < size; x++)
                        {
                            currentBone.dirtMaskTexture.SetPixel(
                            pixelXOffset + x,
                            pixelYOffset + y,
                            Color.black);
                        }

                    }



                    /*int pixelXOffset = pixelX - (dirtBrush.width / 2);
                    int pixelYOffset = pixelY - (dirtBrush.height / 2);

                    for (int x = 0; x < dirtBrush.width; x++)
                    {
                        for (int y = 0; y < dirtBrush.height; y++)
                        {
                            Color pixelDirt = dirtBrush.GetPixel(x, y);
                            Color pixelDirtMask = currentBone.dirtMaskTexture.GetPixel(pixelXOffset + x, pixelYOffset + y);

                            currentBone.dirtMaskTexture.SetPixel(
                                pixelXOffset + x,
                                pixelYOffset + y,
                                new Color(0, pixelDirtMask.g * pixelDirt.g, 0)
                            );
                        }
                    }*/

                    currentBone.dirtMaskTexture.Apply();

                    waitToCheck++;
                    if (waitToCheck % 5 == 0) GameManager.instance.cleanPlace.CheckPolishing();

                    //Vibration.Vibrate(35);
                }
            }
        }
        else
        {
            pos = initPos;

            tool.transform.up = Vector3.Lerp(tool.transform.up, initUp, 10 * Time.deltaTime);
        }

        if (Vector3.Distance(tool.transform.position, pos) > .1f)
        {
            tool.MovePosition(tool.position + (pos - tool.position).normalized * toolSpeed * Time.fixedDeltaTime);
        }


    }
}
