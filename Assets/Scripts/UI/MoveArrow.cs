using UniRx;
using UnityEngine;

namespace UI
{
    public class MoveArrow : MonoBehaviour, ISelectableByClick
    {
        private Subject<Unit> _selectedSubject;
        public IObservable<Unit> OnSelected { get { return _selectedSubject; } }

        private void Awake()
        {
            _selectedSubject = new Subject<Unit>();
        }

        public void Select()
        {
            _selectedSubject.OnNext(Unit.Default);
        }
    }
}
