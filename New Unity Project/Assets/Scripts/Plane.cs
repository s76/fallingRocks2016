using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Core.Model
{
    public class SpaceSlot
    {
        public Vector3 geoPosition;
        public IGeoEntity current;
    }

    public class Plane : MonoBehaviour
    {
        public int SizeX { get; private set; }
        public int SizeZ { get; private set; }

        internal void SpawnCharacter(string characterCodeName, int level, int x, int z)
        {
            var c = CharacterFactory.Instance.Create(characterCodeName);
            c.SetPlane(this);
            c.SetGeoIndex(level, x, z);
        }

        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        public float GroundHeight { get { return transform.position.y + RockSize; }  }

        public float RockSize { get; private set; }
        public string CodeName { get; private set; }
        public int RockFallHeight { get; private set; }
        
        const int maxLevel = 1;

        internal void Initialize(PlaneInitData data)
        {
            CodeName = data.codeName;

            SizeX = data.sizeX;
            SizeZ = data.sizeZ;
            RockSize = data.rockSize;

            RockFallHeight = data.rockFallHeight;

            var currentRockIndex = 0;
            var currentCount = 0;
            for (int x = 0; x < data.sizeX; x++)
            {
                for (int z = 0; z < data.sizeZ; z++)
                {
                    var r = RockFactory.Instance.Create(data.rocks[currentRockIndex].rockCodeName);
                    if(data.rocks[currentRockIndex].amount != -1)
                    {
                        currentCount++;
                        if (currentCount >= data.rocks[currentRockIndex].amount && currentRockIndex + 1 < data.rocks.Count)
                        {
                            currentCount = 0;
                            currentRockIndex++;
                        }
                    }
                    r.SetPlane(this);
                    r.SetGeoIndex(0, x, z);
                }
            }
        }
    
        public Vector3 CalculateLocalGeoPos(int h, int x, int z)
        {
            return new Vector3((x - SizeX / 2f) * RockSize, h*RockSize, (z - SizeZ / 2f) * RockSize);
        }
        public Vector3 CalculateLocalCharacterPos(int h, int x, int z)
        {
            return new Vector3((x - SizeX / 2f) * RockSize, (h - 0.5f)* RockSize , (z - SizeZ / 2f) * RockSize);
        }
        public void RockFall(string rockCodeName, int x, int z )
        {
            var r = RockFactory.Instance.Create(rockCodeName);
            r.SetPlane(this);
            r.SetGeoIndex(0, x, z);

            var des = CalculateLocalGeoPos(1, x, z);
            var start = CalculateLocalGeoPos(RockFallHeight, x, z); 
            
            r.LocalPosition = start;
            r.Fall(start, des);
        }
    }
}

