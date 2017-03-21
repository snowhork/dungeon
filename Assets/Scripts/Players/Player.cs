using FieldObjects;
using Maps;
using UniRx;
using UnityEngine;
using Utility;

namespace Players
{
    [RequireComponent(typeof(PlayerActor))]
    public class Player : ActionObject
    {
        private bool _isPlayerTurn;

        private void Awake()
        {
            base.Awake();
            _isPlayerTurn = false;
        }

        public IObservable<Unit> OnActionFinished
        {
            get { return Actor.OnActionFinished; }
        }

        public override void Action(MapInfo mapInfo)
        {
            MapInfo = mapInfo;
            _isPlayerTurn = true;
            Actor.TurnStart();
        }

        private void Start()
        {
            Actor = GetComponent<PlayerActor>().Initialize(IntTransform, MapInfo);
        }
    }
}
