using UnityEngine;
using System.Collections;
using System;

namespace Core.Model
{
    public enum RockType {  Normal }
    public class Rock : MonoBehaviour
    {
        public AnimationCurve fallSpeedCurve;

        public float FallTime { get; private set; }
        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }
        public Vector3 LocalPosition
        {
            get { return transform.localPosition; }
            set { transform.localPosition = value; }
        }
        public Plane Plane { get; private set; }
        public int IndexX { get; private set; }
        public int IndexZ { get; private set; }
        public string CodeName { get; private set; }

        public bool isFalling;

        public void Initialize (RockInitData data)
        {
            FallTime = data.fallTime;
            CodeName = data.codeName;
        }

        public void SetPlane(Plane plane, int planeIndexX, int planeIndexZ)
        {
            name = "Rock[" + planeIndexX + "," + planeIndexZ + "]";
            Plane = plane;
            IndexX = planeIndexX;
            IndexZ = planeIndexZ;
            transform.SetParent(plane.transform);
            transform.localScale = Vector3.one * plane.RockSize;
        }
    }
}
