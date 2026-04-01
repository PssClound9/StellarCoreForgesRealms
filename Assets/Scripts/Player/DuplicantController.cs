using UnityEngine;

public class DuplicantController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float interactRange = 2f;
    
    private Rigidbody rb;
    private Camera mainCamera;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }
    
    void Update()
    {
        // 移动控制
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        
        // 交互控制
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }
    
    void Interact()
    {
        // 检测周围可交互对象
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactRange);
        
        foreach (Collider collider in hitColliders)
        {
            if (collider.GetComponent<Interactable>())
            {
                collider.GetComponent<Interactable>().Interact();
                break;
            }
        }
    }
}