using FieldObjects;
using Maps;
using UniRx;
using UnityEngine;
using Utility;

namespace Players
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerActor : BaseActor
    {
        private PlayerInput _input;

        public override BaseActor Initialize(IntTransform intTransform, MapInfo mapInfo)
        {
            base.Initialize(intTransform, mapInfo);
            _input = GetComponent<PlayerInput>();
            _input.Initialize(IntTransform, MapInfo);
            _input.OnAction.Where(action => action.Execute()).Subscribe(action =>
            {
                _input.Inputtable = false;
                ActionFinishedSubject.OnNext(Unit.Default);
                Debug.Log("X: " + IntTransform.Position.X);
                Debug.Log("Y: " + IntTransform.Position.Y);
            }).AddTo(this);
            return this;
        }

        public override void TurnStart()
        {
            _input.Inputtable = true;
        }
    }
}
