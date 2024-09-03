using Assets.Script.State_Machine_System.Player_States;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Statemachine/PlyaerState/Idle", fileName = "PlayerStateIdle")]
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
            stateMachine.SwichState(typeof(PlayerStateClimbing));
        }
        if ( input.Jump && Player.IsGound )
        {
            stateMachine.SwichState(typeof(PlayerStateJumpUP));
        }
        if ( input.Move )
        {
            stateMachine.SwichState(typeof(PlayerStateRun));
        }

        if ( !Player.IsGound )
        {
            stateMachine.SwichState(typeof(PlayerStateFall));
        }

       
        currentSpeedX = Mathf.MoveTowards(currentSpeedX, 0, acceleration * Time.deltaTime);

        currentSpeedX = Mathf.MoveTowards(currentSpeedX, 0, acceleration * Time.deltaTime);
    }

    public override void PhysicUpdate ( )
    {
        Player.SetvelocityX(currentSpeedX * Player.transform.localScale.x);
    }
}