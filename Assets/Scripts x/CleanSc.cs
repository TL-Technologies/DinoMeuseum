using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanSc : MonoBehaviour
{
    public bool working = false;

    public LayerMask layer;

    public Rigidbody tool;

    [HideInInspector] public Vector3 initPos,initUp;
    public float toolSpeed = 1;
    Vector3 pos;

    private void Start()
    {
        GameManager.instance.clean = this;
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
                //Debug.Log("HIT::   "+raycastHit.transform.gameObject.name);
                pos = raycastHit.point;
                DustPart dust = raycastHit.transform.GetComponent<DustPart>();
                if (dust!=null && Vector3.Distance(tool.transform.position, pos)<.3f)
                {
                    dust.Destroy();
                }
                

                tool.transform.up = Vector3.Lerp(tool.transform.up, (raycastHit.transform.position-pos).normalized, 10 * Time.deltaTime);
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
