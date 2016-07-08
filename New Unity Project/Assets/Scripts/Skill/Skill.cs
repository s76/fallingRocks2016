using UnityEngine;
using System.Collections;
using System;

namespace Core.Model
{
    public abstract class Skill : MonoBehaviour
    {
        public string CodeName { get; private set; }
        public SkillInitData InitData { get; private set; }
        public IGeoEntity Owner { get; private set; }

        internal virtual void Initialize(SkillInitData initData, IGeoEntity owner)
        {
            Owner = owner;
            InitData = initData;
            CodeName = initData.codeName;
        }
    }
}

