using UnityEngine;

public class BirdControl : MonoBehaviour
{
    [SerializeField] float velocity = 1.5f;
    [SerializeField] float rotateSpeed = 10f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity;
        }
    }
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotateSpeed);
    }
}
