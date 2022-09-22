using Ship.Controls;
using UnityEngine;

namespace UI.Menu
{
    public class ListenToDevices : MonoBehaviour
    {
        public UnityEngine.InputSystem.PlayerInputManager InputManager;
        
        private void OnEnable()
        {
            InputManager.EnableJoining();
            Invoke(nameof(InnitDevices), 0.1f);
        }

        void InnitDevices()
        {
            DeviceManager.Instance.OnListenToDevices();
        }
        private void OnDisable() => InputManager.DisableJoining();
    }
}
