using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity = 120f;
    public bool invertMouseY = false;
    public float moveSpeed = 10f;
    public float jumpForce = 6f;
    public float fallGravity = 15f;
    public bool jumpPressed = false;
    public bool isGrounded = true;
    public float shotDistance = 50f;
    public float shotForce = 15f;

    Transform camBody;
    float pitchRotation;
    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = GetComponentInChildren<Camera>();
        if(cam == null)
        {
            Debug.LogError("You forgot that camera");
        }
        camBody = cam.transform;

        pitchRotation = camBody.rotation.eulerAngles.x;// could be 0f, but just in case. this tells it to take the angles ins degrees of the camera's rotation.
        Cursor.lockState = CursorLockMode.Locked;
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        Shoot();
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }

    }

    void FixedUpdate()
    {
        Move();
        Jump();
        Fall();
    }

    void Look()
    {
        float mX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //if (invertMouseY)
        //{
        //    pitchRotation += mY;
        //}
        //else
        //{
        //    pitchRotation -= mY;
        //}

        pitchRotation += invertMouseY ? mY : -mY; //mouseY is inverted by default

        pitchRotation = Mathf.Clamp(pitchRotation, -90f, 90f);

        camBody.localRotation = Quaternion.Euler(pitchRotation, 0f, 0f);

        transform.Rotate(0f, mX, 0f);
    }

    void Move()
    {
        float moveFB = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveRL = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        Vector3 offset = new Vector3(moveRL, 0f, moveFB);
        //transform.Translate(offset);
        Vector3 newPos = playerRb.position + transform.TransformDirection(offset); //TransformDirection() takes a vector expressed in the GameObject's local coordinate system and converts it into the corresponding direction in world space, taking the GameObject's rotation into account. Basically transtlates local to world so the character moves to the direction they're facing.
        playerRb.MovePosition(newPos); //Better alternative for player movement when physics and rigidbodies are involved.
    }

    void Jump()
    {
        if (jumpPressed && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        jumpPressed = false;
    }

    void Fall()
    {
        if (playerRb.velocity.y < 0)
        {
            playerRb.AddForce(Vector3.down * fallGravity, ForceMode.Acceleration);
        }
    }

    void Shoot()
    {
        if (!Input.GetButtonDown("Fire1"))
        {
            return;
        }
        Ray ray = new Ray(camBody.position, camBody.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, shotDistance))
        {
            if(hit.rigidbody == null)
            {
                return;
            }

            //hit.normal = line that points directly out of a surface
            Vector3 force = (hit.point - transform.position).normalized * shotForce;//-hit.normal * shotForce;
            hit.rigidbody.AddForceAtPosition(force, hit.point, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Crate"))
        {
            isGrounded = true;
        }
    }
}
