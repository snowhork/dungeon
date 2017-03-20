using System.Collections;
using Actions;
using Maps;
using Settings;
using UniRx;
using UnityEngine;
using Utility;

namespace Players
{
    public class PlayerInput : MonoBehaviour
    {
        public IObservable<BaseAction> OnAction { get { return _actionSubject; } }
        private Subject<BaseAction> _actionSubject;
        private IntTransform _intTransform;
        private MapInfo _mapInfo;
        private bool _inputtable;

        public bool Inputtable
        {
            get { return _inputtable; }
            set { _inputtable = value; }
        }

        public PlayerInput Initialize(IntTransform intTransform, MapInfo mapInfo)
        {
            _intTransform = intTransform;
            _mapInfo = mapInfo;
            return this;
        }

        private void Awake()
        {
            _actionSubject = new Subject<BaseAction>();
        }

        private void Update()
        {
            if (!_inputtable) return;
            if (Input.GetAxis("Horizontal") > 0)
            {
                _actionSubject.OnNext(new Move(_intTransform, _mapInfo, new IntVector(0, -1)));
                //StartCoroutine(Rotate(Quaternion.AngleAxis(90f, Vector3.up)*transform.rotation));
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                //StartCoroutine(Rotate(Quaternion.AngleAxis(-90f, Vector3.up)*transform.rotation));
            }

            if (Input.GetAxis("Vertical") > 0)
            {
                //_intTransform.Position += _intTransform.Forward;
                //StartCoroutine(Move(transform.position + Const.MapChipWidth * transform.forward));
            }
        }

        IEnumerator Move(Vector3 final)
        {
            _inputtable = false;
            var start = transform.position;
            for (float i = 0f; i <= 1f; i += 0.15f) {
                transform.position = Vector3.Lerp(start, final, i);
                yield return null;
            }
            transform.position= final;
            _inputtable = true;
        }

        IEnumerator Rotate(Quaternion final)
        {
            _inputtable = false;
            var start = transform.rotation;
            for (float i = 0f; i <= 1f; i += 0.15f) {
                transform.rotation = Quaternion.Lerp(start, final, i);
                yield return null;
            }
            transform.rotation = final;
            _inputtable = true;
        }
    }
}
