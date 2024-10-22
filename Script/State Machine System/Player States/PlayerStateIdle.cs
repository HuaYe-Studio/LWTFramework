using Assets.Script.State_Machine_System.Player_States;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Statemachine/PlayerState/Idle", fileName = "PlayerStateIdle")]
public class PlayerStateIdle : PlayerState
{
    [SerializeField] public float acceleration;
    public override void Enter ( )
    {
        base.Enter();
        currentSpeedX = Mathf.Abs(Player.moveSpeedX);
        Player.audioManager.StopSFX();
        Player.SetvelocityY(0);
      

    }

    private void Update ( )
    {

    }
    public override void LogicUpdate ( )
    {
        if ( Player.CanClimb && input.OnClimb )
        {
            stateMachine.SwitchState(typeof(PlayerStateClimbing));
        }
        if ( input.Jump && Player.IsGound )
        {
            stateMachine.SwitchState(typeof(PlayerStateJumpUP));
        }
        if ( input.Move )
        {
            stateMachine.SwitchState(typeof(PlayerStateRun));
        }

        
        if ( !Player.IsGound )
        {
            stateMachine.SwitchState(typeof(PlayerStateFall));
        }

        if (input.Skill1)
        {
          
            stateMachine.SwitchState(Player.Skills[0]);
        }

       
        currentSpeedX = Mathf.MoveTowards(currentSpeedX, 0, acceleration * Time.deltaTime);

        currentSpeedX = Mathf.MoveTowards(currentSpeedX, 0, acceleration * Time.deltaTime);
    }

    public override void PhysicUpdate ( )
    {
        Player.SetvelocityX(currentSpeedX * Player.transform.localScale.x);
    }
}