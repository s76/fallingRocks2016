using UnityEngine;
using System.Collections;
using System;

namespace Core.Model.Skills
{
    public class MeteorCrash : Skill
    {
        public GameObject rockFinishFallEffect;
        internal override void Initialize(SkillInitData initData, IGeoEntity owner)
        {
            base.Initialize(initData, owner);
            var rock = owner as Rock;
            if(rock == null)
            {
                Debug.LogError("Owner is not a rock");
                return;
            }
            rock.onStateChange += OnRockStateChange;
        }

        private void OnRockStateChange(Rock rock, RockState old, RockState current)
        {
            if( old == RockState.Fall && current == RockState.Disappear)
            {
                var effect = Instantiate(rockFinishFallEffect);
                var rockPos = rock.Position;
                rockPos.y = rock.Plane.GroundHeight;
                effect.transform.position = rockPos;
            }
        }
    }

}
