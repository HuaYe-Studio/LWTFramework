using UnityEngine;



namespace Assets.Script.State_Machine_System.Player_States
{
    [CreateAssetMenu(menuName = "Data/Statemachine/PlayerState/dead", fileName = "PlayerStateDead")]
    public class PlayerStateDead : PlayerState
    {
        public override void Enter ( )
        {
            base.Enter();
           
            // animator.Play("Dead");
        }

        public override void LogicUpdate ( )
        {
            
        }

        public override void PhysicUpdate ( )
        {
            Player.SetvelocityX(0);
            Player.SetvelocityY(0);
        }
    }
}
