using Actions;
using FieldObjects;
using Maps;
using Settings;
using UI;
using UniRx;
using UnityEngine;
using Utility;

namespace Players
{
    [RequireComponent(typeof(ClickSelector))]
    public class PlayerActor : BaseActor
    {
        private ClickSelector _selector;
        [SerializeField] private MoveArrow _moveArrowPref;

        public override BaseActor Initialize(IntTransform intTransform, MapInfo mapInfo)
        {
            base.Initialize(intTransform, mapInfo);
            _selector = GetComponent<ClickSelector>();
//            _input = GetComponent<PlayerInput>();
//            _input.Initialize(IntTransform, MapInfo);
//            _input.OnAction.Where(action => action.Execute()).Subscribe(action =>
//            {
//                _input.Inputtable = false;
//                ActionFinishedSubject.OnNext(Unit.Default);
//                Debug.Log("X: " + IntTransform.Position.X);
//                Debug.Log("Y: " + IntTransform.Position.Y);
//            }).AddTo(this);
            return this;
        }

        public override void TurnStart()
        {
            _selector.Selectable = true;
            var vectors = new IntVector[]
            {
                new IntVector(1, 0),
                new IntVector(0, 1),
                new IntVector(-1, 0),
                new IntVector(0, -1),
            };

            foreach (var vector in vectors)
            {
                var move = new Move(IntTransform, MapInfo, vector);
                if (!move.IsValid) continue;
                var moveArrow = Instantiate(_moveArrowPref);
                moveArrow.transform.position = transform.position +
                                               new Vector3(vector.X * Const.MapChipWidth, 0,
                                                   vector.Y * Const.MapChipWidth);
                moveArrow.OnSelected.Subscribe(_ =>
                {
                    move.Execute();
                });
            }
        }
    }
}
