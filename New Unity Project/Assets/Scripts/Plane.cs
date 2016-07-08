using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Core.Model
{
    public class Plane : MonoBehaviour
    {
        public float rockFallTime;
        public float rockFallHeight;

        public int SizeX { get; private set; }
        public int SizeZ { get; private set; }

        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        internal void Initialize(PlaneInitData data)
        {
            this.SizeX = data.sizeX;
            this.SizeZ = data.sizeZ;
            this.RockSize = data.rockSize;

            staticRocks = new Rock[data.sizeX, data.sizeZ];

            var currentRockIndex = 0;
            var currentCount = 0;
            for (int x = 0; x < data.sizeX; x++)
            {
                for (int z = 0; z < data.sizeZ; z++)
                {
                    var r = RockFactory.Instance.Create(data.rocks[currentRockIndex].rockCodeName);
                    currentCount++;
                    if (currentCount >= data.rocks[currentRockIndex].amount && currentRockIndex + 1 < data.rocks.Count)
                    {
                        currentCount = 0;
                        currentRockIndex++;
                    }

                    staticRocks[x, z] = r;
                    r.SetPlane(this, x, z);
                    r.LocalPosition = StaticRockLocalPos(x, z);

                }
            }

            dynamicRocks = new List<Rock>();
        }

        public float RockSize { get; private set; }

        private Rock[,] staticRocks;
        private List<Rock> dynamicRocks;

        Vector3 StaticRockLocalPos(int x, int z)
        {
            return new Vector3((x - SizeX / 2f) * RockSize, 0, (z - SizeZ / 2f) * RockSize);
        }

        public void RockFall(string rockCodeName, int x, int z )
        {
            var r = RockFactory.Instance.Create(rockCodeName);
            r.SetPlane(this, x, z);
            r.isFalling = true;

            dynamicRocks.Add(r);

            var des = StaticRockLocalPos(x, z);
            des.y += RockSize;
            var start = new Vector3(des.x, des.y + rockFallHeight, des.z);
            
            r.LocalPosition = start;

            StartCoroutine(RockFall2(r, start, des, r.FallTime));
        }

        private IEnumerator RockFall2(Rock r, Vector3 start, Vector3 des, float fallTime)
        {
            yield return null;
            var timer = 0f;
            while(timer < fallTime )
            {
                timer += Time.deltaTime;
                r.LocalPosition = Vector3.LerpUnclamped(start, des, r.fallSpeedCurve.Evaluate(timer/fallTime));
                yield return null;
            }
            r.isFalling = false;
        }
    }
}

