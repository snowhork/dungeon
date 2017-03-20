using Maps;
using UniRx;
using UnityEngine;
using Utility;

namespace FieldObjects
{
    public abstract class BaseActor : MonoBehaviour
    {
        protected IntTransform IntTransform;
        protected MapInfo MapInfo;
        public IObservable<Unit> OnActionFinished { get { return ActionFinishedSubject; } }
        protected Subject<Unit> ActionFinishedSubject;

        protected virtual void Awake()
        {
            ActionFinishedSubject = new Subject<Unit>();
        }

        protected void MoveTo(IntVector position)
        {
            IntTransform.Position = position;
        }

        public virtual BaseActor Initialize(IntTransform intTransform, MapInfo mapInfo)
        {
            MapInfo = mapInfo;
            IntTransform = intTransform;
            return this;
        }

        public abstract void TurnStart();

    }
}
