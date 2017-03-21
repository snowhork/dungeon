using UnityEngine;

namespace UI
{
    public class ClickSelector : MonoBehaviour
    {
        private bool _selectable;

        public bool Selectable
        {
            get { return _selectable; }
            set { _selectable = value; }
        }

        private void Update()
        {
            if(!_selectable) return;
            if (!Input.GetMouseButtonDown(0)) return;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit)) return;

            var selectable = hit.collider.GetComponent<ISelectableByClick>();
            if(selectable == null) return;
            selectable.Select();
        }
    }
}
