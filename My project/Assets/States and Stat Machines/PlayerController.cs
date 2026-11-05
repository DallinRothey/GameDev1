using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    //input
    private InputAction move_action;
    private InputAction jump_action;

    //components
    [HideInInspector] public CharacterController controller;
    [HideInInspector] public MeshRenderer rend;

    //movement
    public float speed = 5;
    [HideInInspector] public Vector2 direction = Vector2.zero;
    [HideInInspector] public Vector2 xz_velcoity = Vector2.zero;
    [HideInInspector] public float y_velocity = 0;
    [HideInInspector] public Vector3 velocity = Vector3.zero;

    //Accelerations
    public float acceleration = 30f;
    public float friction = 25f;
    public float gravity = 9.81f; //must be positive

    //forces
    public float jump_impulse = 10;

    //jumping
    [HideInInspector] public bool jump = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get components
        controller = GetComponent<CharacterController>();
        rend = GetComponent<MeshRenderer>();

        //Find reference to the Move and Jump actions
        move_action = InputSystem.actions.FindAction("Move");
        jump_action = InputSystem.actions.FindAction("Jump");

        //read input into variables
        direction = move_action.ReadValue<Vector2>();
        jump = jump_action.IsPressed(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
