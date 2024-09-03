using UnityEngine;

namespace Assets.Script.Player.Skills
{
    public class SkillBase
    {
        public SkillState State { get; private set; }

        public PlayerController Player { get; private set; }

        public bool HasCooldown { get; private set; }

        public float CooldownTime { get; private set; }

        public SkillBase (float cooldownTime, bool isUnlocked, PlayerController player)
        {
            Player = player;
            CooldownTime = cooldownTime;
            State = isUnlocked ? SkillState.Ready : SkillState.Locked;
            _ = (cooldownTime > 0) ? HasCooldown = true : HasCooldown = false;
        }

        private float _cooldownTimer;

        /// <summary>
        /// 使用技能，如果技能可以触发则返回true，否则返回false
        /// </summary>
        /// <returns></returns>
        public bool TryTrigger ( )
        {
            if ( State == SkillState.Ready && CanTrigger() )
            {
                State = SkillState.Triggering;
                OnTrigger();
                return true;
            }

            return false;
        }

        /// <summary>
        /// 技能触发时调用，用于执行技能的效果（需要重写方法）
        /// </summary>
        public virtual void OnTrigger ( )
        {
            // What happens when the skill is triggered
        }

        /// <summary>
        /// 判断能否触发的条件（除解锁与冷却时间外的条件）（需要重写方法）
        /// </summary>
        public virtual bool CanTrigger ( )
        {
            return true;
        }

        /// <summary>
        /// 每帧更新，用于更新技能的状态（需要重写方法）和冷却时间
        /// </summary>
        public virtual void OnUpdate ( )
        {
            // 更新冷却时间
            _ = _cooldownTimer < Time.deltaTime ? (float)(_cooldownTimer = 0) : (float)(_cooldownTimer -= Time.deltaTime);

            // Debug.Log("Cooldown Timer: " + _cooldownTimer);

            if ( _cooldownTimer <= 0 && State == SkillState.InCooldown )
            {
                Debug.Log("Cooldown finished");
                State = SkillState.Ready;
            }
        }

        /// <summary>
        /// 锁定技能
        /// </summary>
        public void Lock ( )
        {
            State = SkillState.Locked;
        }

        /// <summary>
        /// 解锁技能
        /// </summary>
        public void Unlock ( )
        {
            State = SkillState.Ready;
            _cooldownTimer = 0;
        }

        /// <summary>
        /// 当触发技能完成时调用（比如钩爪收回后需要调用一次），以使技能进入冷却状态
        /// </summary>
        internal void TriggerFinished ( )
        {
            State = SkillState.InCooldown;
            _cooldownTimer = CooldownTime;
        }
    }

    public enum SkillState
    {
        Locked,     // 技能未解锁
        Ready,      // 技能已解锁，可以触发（当然你需要在CanTrigger()里先判断是否可以触发）
        Triggering, // 技能正在执行
        InCooldown, // 技能执行完毕，冷却中
    }
}
