using UnityEngine;
using System.Collections;
using System;
using Core.Managers;
using s76ToolBox.GeneralUse.Extensions;

namespace Core.Model
{
    public enum RockState :int { NotExist, Appear, Fall, Disappear }

    public class Rock : MonoBehaviour, IGeoEntity, ICellEntity
    {
        public Transform Trans { get { return transform; } }
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

        RockState _state;
        public RockState State
        {
            get { return _state; }
            set
            {
                if(value != _state )
                {
                    var old = _state;
                    _state = value;
                    OnStateChange(old, _state);
                    if (onStateChange != null)
                        onStateChange(this, old, _state);
                }
            }
        }
        public AnimationCurve fallSpeedCurve;

        public event Action<Rock,RockState, RockState> onStateChange;
        
        public Plane Plane { get; private set; }
        public string CodeName { get; private set; }
        public RockInitData InitData { get; private set; }
        public RockSkin Skin { get; private set; }

        public bool isFalling;

        public void Initialize (RockInitData data)
        {
            this.InitData = data;

            Skin = SkinFactory.Instance.CreateRockSkin(data.skinName,this);
            foreach( var s in data.skillsName )
            {
                SkillFactory.Instance.Create(s,this);
            }

            CodeName = data.codeName;
            _state = RockState.NotExist;
        }

        public void SetGeoIndex(int level, int planeIndexX, int planeIndexZ)
        {
            IndexX = planeIndexX;
            IndexZ = planeIndexZ;
            IndexH = level;

            LocalPosition = Plane.CalculateLocalGeoPos(level, planeIndexX, planeIndexZ);
            Skin.transform.localScale = Vector3.one * Plane.RockSize;
        }

        public void SetPlane(Plane plane)
        {
            Plane = plane;
            transform.SetParent(plane.transform);
            transform.ResetLocals();
        }

        private IEnumerator RockFall2(Vector3 start, Vector3 des)
        {
            yield return new WaitForSeconds(InitData.appearTime);

            State = RockState.Fall;

            var timer = 0f;
            var fallTime = InitData.fallTime;
            while (timer < fallTime)
            {
                yield return null;
                timer += Time.deltaTime;
                LocalPosition = Vector3.LerpUnclamped(start, des, fallSpeedCurve.Evaluate(timer / fallTime));
            }
            State = RockState.Disappear;
            yield return new WaitForSeconds(InitData.disappearTime);
            Destroy(this.gameObject);
            
        }

        private void OnStateChange(RockState old, RockState _state)
        {
            if (onStateChange != null)
                onStateChange(this, old, _state);
        }

        internal void Fall(Vector3 start, Vector3 des)
        {
            if (State != RockState.NotExist)
            {
                Debug.LogError("State == "+ State);
                return;
            }
            State = RockState.Appear;
            StartCoroutine(RockFall2(start, des));
        }

    }
}
