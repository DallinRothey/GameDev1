using UnityEngine;

public class PLayerMovement : MonoBehaviour
{
    //Components
    private Rigidbody rb;

    //Movement
    public float speed = 5.0f;
    private Vector3 direction = Vector3.zero;
    private Vector3 velocity = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get Components
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Left/right
        direction.x = Input.GetAxisRaw("Horizontal");
        //Up/Down
        direction.z = Input.GetAxisRaw("Vertical");

        //Construct the velocity vector
        velocity = direction * speed;
        velocity *= Time.fixedDeltaTime;
        //Move
        rb.MovePosition(rb.position + velocity);

        Debug.Log("direction: " + direction);
        Debug.Log("Velocity: " + velocity);
        Debug.Log("RB Position: " + rb.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + direction * 2);

    }
}
