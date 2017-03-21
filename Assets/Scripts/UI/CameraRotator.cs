using System.Linq;
using UniRx;
using UnityEngine;

namespace UI
{
    public class CameraRotator : MonoBehaviour
    {
        [SerializeField] private Transform Player;
        private void Update ()
        {
            //if (!Input.GetKey(KeyCode.LeftShift)) return;
//            var yRot = Input.GetAxis("Mouse X") * 2f;
//            var xRot = Input.GetAxis("Mouse Y") * 2f;
            var yRot = Input.GetAxis("Horizontal") * 2f;
            var xRot = Input.GetAxis("Vertical") * 2f;

            Player.transform.localRotation *= Quaternion.Euler (0f, yRot, 0f);
            Camera.main.transform.localRotation *= Quaternion.Euler (-xRot, 0f, 0f);
        }
    }
}
