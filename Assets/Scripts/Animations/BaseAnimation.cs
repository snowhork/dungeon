using System.Collections;
using System.Threading;
using UniRx;
using UnityEngine;

namespace Animations
{
    public abstract class BaseAnimation
    {
        protected Subject<Unit> AnimationSubject;
        public IObservable<Unit> OnAnimationFinished { get { return AnimationSubject; } }
        protected Transform Transform;

        protected BaseAnimation(Transform transform)
        {
            Transform = transform;
            AnimationSubject = new Subject<Unit>();
        }

        public abstract IEnumerator Start();
    }
}
