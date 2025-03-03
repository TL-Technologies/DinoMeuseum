using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public Rigidbody rb;
    public Transform mainChar;

    Vector3 dirSmooth = Vector3.zero;

    bool mooving = true;
    public float speed;


    float curSpeed;
    Vector3 previousPosition;

    public Animator anim;

    void FixedUpdate()
    {
        Vector3 curMove = transform.position - previousPosition;
        curSpeed = (curMove.magnitude / Time.deltaTime) / speed;
        previousPosition = transform.position;

        anim.SetFloat("Movement", curSpeed);



        Vector3 direction = Camera.main.transform.parent.forward * joystick.Vertical + Camera.main.transform.parent.right * joystick.Horizontal;
        direction = new Vector3(direction.x, 0, direction.z);
        dirSmooth = Vector3.Lerp(dirSmooth, direction, Time.fixedDeltaTime * 15);

        if (!mooving) return;

        rb.MovePosition(rb.position + dirSmooth * speed * Time.deltaTime);

        if (direction != Vector3.zero) mainChar.rotation = Quaternion.Lerp(mainChar.rotation, Quaternion.LookRotation(direction), 10 * Time.fixedDeltaTime);
    }

    public void SetState(bool state)
    {
        mooving = state;
        joystick.gameObject.SetActive(state);
    }


}
