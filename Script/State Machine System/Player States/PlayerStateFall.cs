using Assets.Script.State_Machine_System.Player_States;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Statemachine/PlyaerState/Fall", fileName = "PlayerStateFall")]
public class PlayerStateFall : PlayerState
{
    // Start is called before the first frame update
    [SerializeField]
    private AnimationCurve speedcuCurve;

   
    
    [SerializeField]
    public float speed = 5f;

    [SerializeField]
    public float acceleration = 15f;

    public override void Enter ( )
    {
        base.Enter();

      
    }

    public override void LogicUpdate ( )
    {
       
        if ( Player.IsGound )
        {
            stateMachine.SwichState(typeof(PlayerStateLand));
        }
       
        if ( Player.CanClimb && input.OnClimb )
        {
            stateMachine.SwichState(typeof(PlayerStateClimbing));
        }

        if (input.Jump)
        {
            input.SetJumpBufferTimer();
            //input.HasJumpInputBuffer = true;
            
        }
        
    }

    public override void PhysicUpdate ( )
    {
        currentSpeedX = Player.moveSpeedX;
        Player.SetvelocityY(speedcuCurve.Evaluate(stateTime));
        //Debug.Log($"Player.moveSpeedX {Player.moveSpeedX} input.AxisX * speed {input.AxisX * speed}");
        
        if ( Mathf.Abs(currentSpeedX) < Mathf.Abs(input.AxisX * speed)
            || (input.AxisX * currentSpeedX < 0
                && Mathf.Abs(input.AxisX) > 0.5) )
        {
            Player.SetvelocityX(Mathf.MoveTowards(currentSpeedX, input.AxisX * speed, acceleration * Time.deltaTime));
        }
        else
        {
            Player.SetvelocityX(input.AxisX*speed);
        }
        //Player.Move(currentSpeedX);
    }
    
}
