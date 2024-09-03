using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Statemachine/PlyaerState/Climbing",fileName = "PlayerStateClimbing")]

public class PlayerStateClimbing : PlayerState
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    [SerializeField]public float climbSpeed=5f,gravityScale=4;
    // Start is called before the first frame update
    
    public override void Enter()
    {
        base.Enter();
        Player.GetOnLadder();
        Player.SetGravity(0);
        Player.SetvelocityX(0);
        
    }
    
    public override void LogicUpdate()
    {
        if (input.Jump)
        {
            stateMachine.SwichState(typeof(PlayerStateJumpUP));
        }

        if (!Player.CanClimb)
        {
            stateMachine.SwichState(typeof(PlayerStateFall));
        }
        if (Player.IsGound&& input.AxisY==0)
        {
            stateMachine.SwichState(typeof(PlayerStateIdle));
        }
        if (input.AxisY == 0)
        {
            animator.speed = 0f;
        }
        if (input.AxisY != 0)
        {
            animator.speed = 1f;
        }
    }
    public override void Exit()
    { 
        
        
        Player.SetGravity(gravityScale);
    }
    public override void PhysicUpdate()
    { 
        
        
        Player.Climb(climbSpeed);
        //Debug.Log(10)
    }
}
