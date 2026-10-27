using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //input
    private InputAction move_action;
    private InputAction jump_action;

    //Components
    private Rigidbody rb;

    //Movement
    public float speed = 5.0f;
    private Vector3 direction = Vector3.zero;
    private Vector3 velocity = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        //Input
        move_action = InputSystem.actions.FindAction("Move");
        jump_action = InputSystem.actions.FindAction("Jump");
        */
        //Get Components
        rb = GetComponent<Rigidbody>();
    }
    public void ReadMoveInput(InputAction.CallbackContext context)
    {
        direction.x = context.ReadValue<Vector2>().x;
        direction.z = context.ReadValue<Vector2>().y;
    }
    void Update()
    {
        /*
        //get direction
        direction.x = move_action.ReadValue<Vector2>().x;
        direction.z = move_action.ReadValue<Vector2>().y;
        */
    }
    // Update is called once per frame
    void FixedUpdate()
    {
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
        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(transform.position, transform.position + direction * 2);

    }
}
