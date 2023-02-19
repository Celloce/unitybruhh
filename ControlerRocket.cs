using UnityEngine;

public class ControlerRocket : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        moveDirection = new Vector2(x, y);
    }

    void FixedUpdate()
    {
        rb.velocity = moveDirection * speed * Time.deltaTime;

        if (rb.velocity != Vector2.zero)
        {
            transform.up = rb.velocity;
        }
    }
}
