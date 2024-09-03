using UnityEngine;
[CreateAssetMenu(menuName = "Data/Statemachine/PlyaerState/Land", fileName = "PlayerStateLand")]
public class PlayerStateLand : PlayerState
{
    // Start is called before the first frame update
    public override void Enter ( )
    {
        base.Enter();

        currentSpeedX = Mathf.Abs(Player.moveSpeedX);
        
    }

    public override void LogicUpdate ( )
    {
      
        if ( input.Move )
        {
            stateMachine.SwichState(typeof(PlayerStateRun));
        }

        if ( IsAnimationFinished )
        {
            stateMachine.SwichState(typeof(PlayerStateIdle));
        }
       
        if ( input.Jump ||input.HasJumpInputBuffer)
        {
            stateMachine.SwichState(typeof(PlayerStateJumpUP));
        }
    }

    public override void PhysicUpdate ( )
    {
        Player.SetvelocityX(0);

    }
}
