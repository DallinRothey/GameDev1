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

    //jump
    if (player_controller.jump)
    {
        player_controller.y_velocity = player_controller.jump_impulse;
        current_state = States.Air;
        return;
    }
    }
    private void GroundState()
    {
        //Change color to green.
        player_controller.rend.material.color = Color.green;
        
        //acceleration
        player_controller.xz_velocity += player_controller.direction * player_controller.acceleration * Time.fixedDeltaTime;
        player_controller.xz_velocity = Vector2.ClampMagnitude(player_controller.xz_velocity, player_controller.speed);

        //friction
        if (player_controller.direction == Vector2.zero)
        {
            player_controller.xz_velocity = Vector2.MoveTowards(
                player_controller.xz_velocity,
                Vector2.zero,
                player_controller.friction * Time.fixedDeltaTime
            );
        }
        
        //Construct velocity
        player_controller.velocity = new Vector3(player_controller.xz_velocity.x,
                                                -player_controller.gravity,
                                                player_controller.xz_velocity.y);

        //move
        player_controller.controller.Move(player_controller.velocity * Time.fixedDeltaTime);

        //Sync velocities after the move.
        player_controller.velocity = player_controller.controller.velocity;
        player_controller.xz_velocity = new Vector3(player_controller.controller.velocity.x,
                                                    player_controller.controller.velocity.z);

        
        #region Change States
        if (player_controller.controller.velocity == Vector3.zero)
        {
            if(player_controller.direction == Vector2.zero)
            {
                current_state = States.Idle;
                return;
            }
        }
        #endregion

        //jump
    if (player_controller.jump && player_controller.controller.isGrounded)
    {
        player_controller.y_velocity = player_controller.jump_impulse;
        current_state = States.Air;
        return;
    }
    if (!player_controller.controller.isGrounded)
    {
        current_state = States.Air;
        return;
    }
    }   

    private void AirState()
    {
        //Change color to blue.
        player_controller.rend.material.color = Color.blue;
        
        //acceleration
        player_controller.xz_velocity += player_controller.direction * player_controller.acceleration * Time.fixedDeltaTime;
        player_controller.xz_velocity = Vector2.ClampMagnitude(player_controller.xz_velocity, player_controller.speed);

        //gravity
        player_controller.y_velocity -= player_controller.gravity * Time.fixedDeltaTime;
        
        //Construct velocity
        player_controller.velocity = new Vector3(player_controller.xz_velocity.x,
                                                player_controller.y_velocity,
                                                player_controller.xz_velocity.y);

        //move
        player_controller.controller.Move(player_controller.velocity * Time.fixedDeltaTime);

        if (player_controller.controller.isGrounded)
        {
            if (player_controller.xz_velocity == Vector2.zero)
            {
                current_state = States.Idle;
            }
            else
            {
                current_state = States.Ground;
            }
            return;
        }

        //Sync velocities after the move.
        player_controller.velocity = player_controller.controller.velocity;
        player_controller.xz_velocity = new Vector3(player_controller.controller.velocity.x,
                                                    player_controller.controller.velocity.z);
        player_controller.y_velocity = player_controller.controller.velocity.y;

        //jump
    if (player_controller.jump)
    {
        player_controller.y_velocity = player_controller.jump_impulse;
        current_state = States.Air;
        return;
    }
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
