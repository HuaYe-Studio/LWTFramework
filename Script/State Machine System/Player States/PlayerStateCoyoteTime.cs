using UnityEngine;
[CreateAssetMenu(menuName = "Data/Statemachine/PlayerState/CoyoteTime", fileName = "PlayerStateCoyoteTime")]
public class PlayerStateCoyoteTime : PlayerState
{

    [SerializeField]public float coyoteTime=1f,speed;
    // Start is called before the first frame update

    public override void Enter ( )
    {
        base.Enter();

        currentSpeedX = Mathf.Abs(Player.moveSpeedX);
        
    }

    public override void LogicUpdate ( )
    {
       
        if ( input.Jump )
        {
            stateMachine.SwitchState(typeof(PlayerStateJumpUP));
        }

        if ( !input.Move || coyoteTime <= stateTime )
        {
            stateMachine.SwitchState(typeof(PlayerStateFall));
        }

       
        if ( Player.CanClimb && input.OnClimb )
        {
            stateMachine.SwitchState(typeof(PlayerStateClimbing));
        }
      


    }

    public override void PhysicUpdate ( )
    {
        //Debug.Log(10);
        Player.Move(speed);
    }
}