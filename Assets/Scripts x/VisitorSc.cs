using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorSc : MonoBehaviour
{
    public float speed;


    float curSpeed;
    Vector3 previousPosition;

    public Animator anim;
    public bool autoRotation;

    public Transform target;

    public Rigidbody rb;

    public int styleCount = 6;
    float targetStyle=0;
    public GameObject[] pants;

    private void Awake()
    {
        pants[Random.Range(0, pants.Length)].SetActive(true);
    }
    private void Start()
    {
        StartCoroutine(UpdateIdle());
        StartCoroutine(IdleSmooth());
    }
    IEnumerator UpdateIdle()
    {
        while (true)
        {
            targetStyle = Random.Range(0f, styleCount) / (float)styleCount;
            yield return new WaitForSeconds(Random.Range(1f, 4f));
        }
    }
    IEnumerator IdleSmooth()
    {
        while (true)
        {
            anim.SetFloat("IdleStyle", Mathf.Lerp(anim.GetFloat("IdleStyle"),targetStyle,Time.deltaTime*2));
            yield return new WaitForEndOfFrame();
        }
    }

    private void FixedUpdate()
    {
        Vector3 curMove = transform.position - previousPosition;
        curSpeed = (curMove.magnitude / Time.deltaTime) / speed;
        previousPosition = transform.position;

        anim.SetFloat("Movement", curSpeed);


        if (autoRotation)
        {
            if (curMove != Vector3.zero)
            {
                Vector3 rot = Quaternion.LookRotation(curMove, Vector3.up).eulerAngles;
                transform.eulerAngles = new Vector3(0, Mathf.LerpAngle(transform.eulerAngles.y, rot.y, Time.deltaTime * 6), 0);
            }
            else
            {
                Vector3 rot = Quaternion.LookRotation(target.parent.transform.position - transform.position, Vector3.up).eulerAngles;
                transform.eulerAngles = new Vector3(0, Mathf.LerpAngle(transform.eulerAngles.y, rot.y, Time.deltaTime * 6), 0);
            }
        }

        if (target!=null && Vector3.Distance(transform.position, target.position) > .5f)
        {
            rb.MovePosition(transform.position + (target.position - transform.position).normalized * speed * Time.fixedDeltaTime);
        }
    }
}
