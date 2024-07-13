using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private float _acceleration = 0.1f;
    private Rigidbody rb;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private bool _isGrounded;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on the character.");
        }
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
    private void Update()
    {
        float moveDirection = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal");

        if (moveDirection>0)
        {
            if (_speed<=_maxSpeed)
            {
               _speed += _acceleration * Time.deltaTime; // Increment speed over time
            }
            transform.position += transform.forward * moveDirection * _speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (rotation!=0)
        {
            transform.eulerAngles += new Vector3(0f, rotation * _rotationSpeed * Time.deltaTime, 0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the character is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded= false;
        }
    }
}
