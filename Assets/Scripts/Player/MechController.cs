using UnityEngine;

public class MechController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 120f;
    public float jumpForce = 500f;
    
    private Rigidbody rb;
    private bool isGrounded = true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        // 移动控制
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        // 移动
        Vector3 movement = transform.forward * vertical * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        
        // 转向
        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
        
        // 跳跃
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}