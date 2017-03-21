using System.Collections.Generic;
using Actions;
using Animations;
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
            print("trunstart");
            _selector.Selectable = true;
            var vectors = new IntVector[]
            {
                new IntVector(1, 0),
                new IntVector(0, 1),
                new IntVector(-1, 0),
                new IntVector(0, -1),
            };

            var moveArrows = new List<MoveArrow>();

            foreach (var vector in vectors)
            {
                var move = new Move(IntTransform, MapInfo, vector);
                if (!move.IsValid) continue;
                var moveArrow = Instantiate(_moveArrowPref);
                moveArrow.transform.position = transform.position +
                                               new Vector3(vector.X * Const.MapChipWidth, 0,
                                                   vector.Y * Const.MapChipWidth);
                moveArrows.Add(moveArrow);
                moveArrow.OnSelected.Subscribe(_ =>
                {
                    move.Execute();
                    var anim = new MoveAnimation(transform, moveArrow.transform.position);
                    StartCoroutine(anim.Start());
                    _selector.Selectable = false;
                    anim.OnAnimationFinished.Subscribe(__ =>
                    {
                        foreach (var arrow in moveArrows)
                        {
                            Destroy(arrow.gameObject);
                        }
                        moveArrows.Clear();
                        ActionFinishedSubject.OnNext(Unit.Default);
                    });
                });
            }
        }
    }
}
