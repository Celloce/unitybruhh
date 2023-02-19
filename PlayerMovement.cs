using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, scaleX;
    private Animator animator;
    public KeyCode keykanan = KeyCode.RightArrow, keyKiri = KeyCode.LeftArrow;
    Rigidbody2D rb;
    Transform tr;

    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        scaleX = transform.localScale.x;
        animator = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void kiri()
    {
        transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);
        transform.Translate(Vector3.left * speed * Time.fixedDeltaTime, Space.Self);
        animator.SetBool("Run", true);
    }

    void kanan()
    {
        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        transform.Translate(Vector3.right * speed * Time.fixedDeltaTime, Space.Self);
        animator.SetBool("Run", true);
    }

    void stop()
    {
        animator.SetBool("Run", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(keyKiri))
        {
            kiri();
        }
        else if(Input.GetKey(keykanan))
        {
            kanan();
        }
        else if(Input.GetKeyUp(keyKiri) || Input.GetKeyUp(keykanan))
        {
            stop();
        }
    }
}
