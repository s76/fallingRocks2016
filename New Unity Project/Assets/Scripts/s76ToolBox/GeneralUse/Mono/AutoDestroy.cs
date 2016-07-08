using UnityEngine;
using System.Collections;

namespace s76ToolBox.GeneralUse.Mono
{
    public class AutoDestroy : MonoBehaviour
    {
        public float time = 2f;

        void Awake ()
        {
            Destroy(gameObject, time);
        }
    }
}

