using System.Collections;
using Actions;
using UniRx;
using UnityEngine;

namespace Animations
{
    public class MoveAnimation : BaseAnimation
    {
        private Vector3 _target;
        public MoveAnimation(Transform transform, Vector3 target) : base(transform)
        {
            _target = target;
        }

        public override IEnumerator Start()
        {
            var start = Transform.position;
            for (float i = 0f; i <= 1f; i += 0.15f) {
                Transform.position = Vector3.Lerp(start, _target, i);
                yield return null;
            }
            Transform.position= _target;
            AnimationSubject.OnNext(Unit.Default);
        }

    }
}
