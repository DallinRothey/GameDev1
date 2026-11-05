using UnityEngine;

public class SimpleStateMachine : MonoBehaviour
{
    private PlayerController player_controller;
    
    //states
    enum States
    {
        Idle,
        Ground,
        Air
    }
    private States current_state = States.Idle;

    private void IdleState()
    {
        player_controller.rend.material.color = Color.darkGreen;
        #region Change States
    //Ground State
    if (player_controller.direction != Vector2.zero)
    {
        current_state = States.Ground;
        return;
    }
    #endregion
    }
    private void GroundState()
    {
        //Change color to green.
        player_controller.rend.material.color = Color.green;
        //Move
        Vector3 xz_dir = new Vector3(player_controller.direction.x, 0, player_controller.direction.y);
        player_controller.controller.Move(xz_dir * player_controller.speed * Time.fixedDeltaTime);
        #region Change States
        if (player_controller.controller.velocity == Vector3.zero)
        {
            current_state = States.Idle;
            return;
        }
        #endregion
    }   
    private void AirState()
    {

    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_controller = GetComponent<PlayerController>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (current_state)
        {
            case States.Idle:
                IdleState();
                break;

            case States.Ground:
                GroundState();
                break;

            case States.Air:
                AirState();
                break;

        }
    }
}
