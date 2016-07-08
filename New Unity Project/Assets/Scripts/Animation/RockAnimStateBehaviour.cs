using UnityEngine;
using System.Collections;
using Core.Model;
using System;

public class RockAnimStateBehaviour : AnimStateBehaviour
{
    private Rock owner;
    
    public void Initialize(Rock owner)
    {
        this.owner = owner;
        owner.onStateChange += OnRockStateChange;
    }

    private void OnRockStateChange(Rock rock, RockState stateOld, RockState stateCurrent)
    {
        switch( stateCurrent )
        {
            case RockState.NotExist:
                _CurrentAnimationDuration = -1f;
                break;
            case RockState.Appear:
                _CurrentAnimationDuration = rock.InitData.appearTime;
                break;
            case RockState.Fall:
                _CurrentAnimationDuration = rock.InitData.fallTime;
                break;
            case RockState.Disappear:
                _CurrentAnimationDuration = rock.InitData.disappearTime;
                break;
            default:
                Debug.LogError("State not supported : " + stateCurrent);
                break;
        }
    }
}
