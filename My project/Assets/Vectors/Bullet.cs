using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Movement
    private Rigidbody rb;
    public float speed = 16;
    private Vector3 velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get components
        rb = GetComponent<Rigidbody>();

        //destroy after five seconds
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + (velocity * Time.fixedDeltaTime));
    }
    public void SetVelocity(Vector3 direction)
    {
        //Construct velocity vector
        velocity = direction * speed;
    }
}
