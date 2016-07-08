using UnityEngine;

namespace s76ToolBox.GeneralUse.Extensions
{
    public static class TransformExtensions
    {
        public static void ResetLocals(this Transform trans)
        {
            trans.localRotation = Quaternion.identity;
            trans.localPosition = Vector3.zero;
            trans.localScale = Vector3.one;
        }
    }

}

