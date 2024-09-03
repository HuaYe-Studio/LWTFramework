using UnityEngine;
[CreateAssetMenu(menuName = "Data/Statemachine/PlyaerState/CoyoteTime", fileName = "PlayerStateCoyoteTime")]
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
            stateMachine.SwichState(typeof(PlayerStateJumpUP));
        }

        if ( !input.Move || coyoteTime <= stateTime )
        {
            stateMachine.SwichState(typeof(PlayerStateFall));
        }

       
        if ( Player.CanClimb && input.OnClimb )
        {
            stateMachine.SwichState(typeof(PlayerStateClimbing));
        }
      


    }

    public override void PhysicUpdate ( )
    {
        //Debug.Log(10);
        Player.Move(speed);
    }
}