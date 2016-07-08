using UnityEngine;
using System.Collections;

namespace s76ToolBox.GeneralUse.Mono
{
    public class ParticleSystemPlaybackSpeed : MonoBehaviour
    {
        public float speed;
        public float scale;
        public ParticleSystem[] particleSystems;
        public Transform scaleRoot;

        void Awake()
        {
            UpdateReference();
            SetSpeed();
        }

        public void UpdateReference()
        {
            if (particleSystems == null || particleSystems.Length == 0)
            {
                particleSystems = GetComponentsInChildren<ParticleSystem>(true);
            }
        }

        public void SetScale()
        {
            scaleRoot.localScale = new Vector3(scale, scale ,scale);
        }
        public void SetScale(float s)
        {
            scale = s;
            SetScale();
        }

        public void SetSpeed()
        {
            for (int i = 0; i < particleSystems.Length; i++)
            {
                particleSystems[i].playbackSpeed = speed;
            }
        }

        public void SetSpeed(float s)
        {
            speed = s;
            SetSpeed();
        }
    }
}

