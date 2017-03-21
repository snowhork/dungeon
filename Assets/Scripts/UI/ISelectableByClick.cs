using UniRx;

namespace UI
{
    public interface ISelectableByClick
    {
        void Select();
        IObservable<Unit> OnSelected { get; }
    }
}
