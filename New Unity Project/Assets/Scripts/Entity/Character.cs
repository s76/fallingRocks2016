using s76ToolBox.GeneralUse.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Core.Model
{
    public class Character : MonoBehaviour, IGeoEntity, ICellEntity
    {
        public event Action<Character, int, int, int> onStepOnCell;
        public string CharacterName { get; private set; }
        public string CodeName { get; private set; }
        public Transform Trans {  get { return transform; } }
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

        public int IndexX { get; private set; }
        public int IndexZ { get; private set; }
        public int IndexH { get; private set; }

        public CharacterSkin Skin { get; private set; }
        public List<Skill> Skills { get; private set; }
        public Plane Plane { get; private set; }

        public float oneCellMoveTime = 1f;

        float _moveProgress;
        public float MoveProgress
        {
            get { return _moveProgress; }
            set
            {
                _moveProgress = Mathf.Clamp01(value);
                LocalPosition = Vector3.Lerp(firstMovePoint, secondMovePoint, _moveProgress);
            }
        }

        public void Initialize(CharacterInitData data )
        {
            CodeName = data.codeName;
            CharacterName = data.characterName;

            Skin = SkinFactory.Instance.CreateCharacterSkin(data.skinName, this);

            Skills = new List<Skill>();
            foreach( var e in data.skillsName)
            {
                var s = SkillFactory.Instance.Create(e,this);
                Skills.Add(s);
            }
        }

        public void SetPlane(Plane plane)
        {
            this.Plane = plane;
            transform.SetParent(plane.transform);
            transform.ResetLocals();
        }

        public void SetGeoIndex(int level, int planeIndexX, int planeIndexZ)
        {
            IndexH = level;
            IndexX = planeIndexX;
            IndexZ = planeIndexZ;

            LocalPosition = Plane.CalculateLocalCharacterPos(level, planeIndexX, planeIndexZ);
        }


        #region movement section

        int firstIndexX, firstIndexZ, secondIndexX, secondIndexZ;
        Vector3 firstMovePoint,secondMovePoint;
        int currentMoveDirX, currentMoveDirZ;

        public void Move(float xInput, float zInput, float deltaTime )
        {
            var weigthX = Mathf.Abs(xInput) >= Mathf.Abs(zInput);

            int dirX = xInput == 0 ? 0 : (xInput > 0 ? 1 : -1);
            int dirZ = zInput == 0 ? 0 : (zInput > 0 ? 1 : -1);

            dirX = weigthX ? dirX : (dirZ == 0 ? dirX : 0);
            dirZ = weigthX ? (dirX == 0 ? dirZ : 0) : dirZ;

            if (dirX == 0 && dirZ == 0) return;
            if( currentMoveDirX == 0 && currentMoveDirZ == 0)
            {
                StartMove(dirX, dirZ);
            }
            else if (currentMoveDirX == dirX && currentMoveDirZ == dirZ )
            {
                ContinueMove(deltaTime);
            }
            else if(currentMoveDirX == -dirX && currentMoveDirZ == -dirZ)
            {
                ReverseMove();
                ContinueMove(deltaTime);
            } else
            {
                if (MoveProgress < 0.5f)
                {
                    ReverseMove();
                    ContinueMove(deltaTime);
                }
                else
                {
                    ContinueMove(deltaTime);
                }
            }

            if (MoveProgress > 0.99f)
            {
                FinishMove();
            }
        }

        private void FinishMove()
        {
            currentMoveDirX = 0;
            currentMoveDirZ = 0;
        }

        private void StartMove(int dirX, int dirZ)
        {
            firstIndexX = IndexX;
            firstIndexZ = IndexZ;
            secondIndexX = IndexX + dirX;
            secondIndexZ = IndexZ + dirZ;

            UpdateMovePoints();

            MoveProgress = 0;

            currentMoveDirX = dirX;
            currentMoveDirZ = dirZ;
        }

        void UpdateMovePoints ()
        {
            firstMovePoint = Plane.CalculateLocalCharacterPos(IndexH, firstIndexX, firstIndexZ);
            secondMovePoint = Plane.CalculateLocalCharacterPos(IndexH, secondIndexX, secondIndexZ);
        }

        private void ReverseMove()
        {
            int ix = firstIndexX;
            firstIndexX = secondIndexX;
            secondIndexX = ix;

            int iz = firstIndexZ;
            firstIndexZ = secondIndexZ;
            secondIndexZ = iz;

            currentMoveDirX = -currentMoveDirX;
            currentMoveDirZ = -currentMoveDirZ;

            UpdateMovePoints();

            MoveProgress = 1 - MoveProgress;
        }

        private void ContinueMove(float deltaTime)
        {
            MoveProgress += deltaTime / oneCellMoveTime;
            if (MoveProgress > 0.5f)
            {
                IndexX = secondIndexX;
                IndexZ = secondIndexZ;
            }
        }
    }
    #endregion
}
