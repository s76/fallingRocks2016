using UnityEngine;

namespace Core.Model
{
    public class RockSkin : Skin
    {
        public Animator animator;
        public override void Initialize(IGeoEntity entity)
        {
            base.Initialize(entity);

            Rock rock = entity as Rock;
            if(rock == null)
            {
                Debug.LogError("Entity is not a rock");
                return;
            }

            rock.onStateChange += OnRockStateChange;

            var stateBehaviours = animator.GetBehaviours<RockAnimStateBehaviour>();
            for(int i=0; i< stateBehaviours.Length; i++ )
            {
                stateBehaviours[i].Initialize(rock);
            }
        }

        private void OnRockStateChange(Rock rock, RockState old, RockState current)
        {
            animator.SetInteger("State",(int) current);
        }
    }
}
