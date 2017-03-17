using Settings;
using UnityEngine;
using Utility;

namespace FieldObjects
{
    public abstract class FieldObject : MonoBehaviour
    {
        private IntTransform _intTransform;

        public IntTransform IntTransform
        {
            get { return _intTransform; }
            set { _intTransform = value; }
        }

        protected virtual void Awake()
        {
            _intTransform = new IntTransform();
        }

        public void SetTransform()
        {
             transform.position = new Vector3(IntTransform.Position.X*Const.MapChipWidth, 0f, IntTransform.Position.Y*Const.MapChipWidth);
        }
    }
}