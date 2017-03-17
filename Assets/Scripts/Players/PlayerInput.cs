using System.Collections;
using Settings;
using UniRx;
using UnityEngine;
using Utility;

namespace Players
{
    public class PlayerInput : MonoBehaviour
    {
        public IObservable<Unit> OnActionFinished { get { return _actionFinishedSubject; } }
        private Subject<Unit> _actionFinishedSubject;
        private IntTransform _intTransform;
        private bool _inputtable;

        public bool Inputtable
        {
            get { return _inputtable; }
            set { _inputtable = value; }
        }

        public PlayerInput Initialize(IntTransform intTransform)
        {
            _intTransform = intTransform;
            return this;
        }

        private void Awake()
        {
            _actionFinishedSubject = new Subject<Unit>();
        }

        private void Update()
        {
            if (!_inputtable) return;
            if (Input.GetAxis("Horizontal") > 0)
            {
                StartCoroutine(Rotate(Quaternion.AngleAxis(90f, Vector3.up)*transform.rotation));
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                StartCoroutine(Rotate(Quaternion.AngleAxis(-90f, Vector3.up)*transform.rotation));
            }

            if (Input.GetAxis("Vertical") > 0)
            {
                _intTransform.Position += _intTransform.Forward;
                StartCoroutine(Move(transform.position + Const.MapChipWidth * transform.forward));
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