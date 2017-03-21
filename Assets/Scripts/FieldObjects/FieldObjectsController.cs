using System;
using System.Collections.Generic;
using Maps;
using Players;
using UnityEngine;
using UniRx;
using Utility;

namespace FieldObjects
{
    public class FieldObjectsController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private MapController _mapControllerPrefs;
        private MapController _mapController;
        private List<ActionObject> _actionObjects;

        private void Awake()
        {
            _actionObjects = new List<ActionObject>();
        }

        private void Start()
        {
            _mapController = Instantiate(_mapControllerPrefs).Initialize();
            _player.Initialize(new IntVector(1,2), _mapController.MapInfo);

            Observable.Return(Unit.Default)
                .Delay(TimeSpan.FromSeconds(1f))
                .Subscribe(_ =>
                {
                    _player.Action(_mapController.MapInfo);
                    _player.OnActionFinished.Subscribe(__ =>
                    {
                        Debug.Log("actionfinished");
                        _player.Action(_mapController.MapInfo);
                    });
                });

        }

    }
}
