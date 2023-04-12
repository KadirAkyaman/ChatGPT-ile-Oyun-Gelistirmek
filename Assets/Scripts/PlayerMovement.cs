using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    float horizontalInput;
    float verticalInput;
    public float rotationSpeed = 5.0f;

    //JUMP
    public float jumpForce = 10f;
    public bool isGrounded = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();

        float mouseHorizontal = Input.GetAxis("Mouse X") * rotationSpeed;

        transform.Rotate(0, mouseHorizontal, 0);

        // Space tuþuna basýldýðýnda ve karakter yerdeyken zýplat.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }


    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.forward * 2 * speed * Time.deltaTime * verticalInput);
            transform.Translate(Vector3.right * 2 * speed * Time.deltaTime * horizontalInput);
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Yere temas ettiðinde isGrounded true olur.
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Cube"))
        {
            isGrounded = true;
        }
    }
}
