using s76ToolBox.GeneralUse.Extensions;
using System;
using UnityEngine;

namespace Core.Model
{
    public abstract class Skin : MonoBehaviour
    {
        public virtual void Initialize(IGeoEntity entity)
        {
            transform.SetParent(entity.Trans);
            transform.ResetLocals();
        }
    }
}
