using FieldObjects;
using Maps;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Utility;

namespace Players
{
    [RequireComponent(typeof(PlayerInput))]
    public class Player : ActionObject
    {
        private PlayerInput _playerInput;
        private MapInfo _mapInfo;
        private bool _isPlayerTurn;

        public void Awake()
        {
            base.Awake();
            _isPlayerTurn = false;
        }

        public IObservable<Unit> OnActionFinished
        {
            get { return _playerInput.OnActionFinished; }
        }

        public override void Action(MapInfo mapInfo)
        {
            _mapInfo = mapInfo;
            _isPlayerTurn = true;
            _playerInput.Inputtable = true;
        }

        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>().Initialize(IntTransform);
            IntTransform.Position = new IntVector(1, 2);
            IntTransform.Forward = new IntVector(1, 0);
            SetTransform();
        }



        private void Update()
        {

        }


    }
}