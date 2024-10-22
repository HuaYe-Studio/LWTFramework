using Assets.Script.State_Machine_System.Player_States;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Statemachine/PlayerState/Run", fileName = "PlayerStateRun")]
public class PlayerStateRun : PlayerState
{

    [SerializeField]public float speed=5,acceleration;
    [SerializeField]AudioClass audioClass;
    // Start is called before the first frame update

    public override void Enter ( )
    {
        base.Enter();

        currentSpeedX = Mathf.Abs(Player.moveSpeedX);
        Player.audioManager.SetLoopSFX(true);
        Player.audioManager.PlayDelaySFX(audioClass,0.2f);
    }

    public override void LogicUpdate ( )
    {
        
        if ( input.Jump && Player.IsGound )
        {
            stateMachine.SwitchState(typeof(PlayerStateJumpUP));
        }
       
        if ( !input.Move )
        {
            stateMachine.SwitchState(typeof(PlayerStateIdle));
        }
        if ( !Player.IsGound )
        {
            stateMachine.SwitchState(typeof(PlayerStateCoyoteTime));
        }
        if ( Player.CanClimb && input.OnClimb )
        {
            stateMachine.SwitchState(typeof(PlayerStateClimbing));
        }
        currentSpeedX = Mathf.MoveTowards(currentSpeedX, speed, acceleration * Time.deltaTime);
    }

   

    public override void PhysicUpdate ( )
    {
        //Debug.Log(10);
        Player.Move(currentSpeedX);
    }
}