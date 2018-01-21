using UnityEngine;
using Vuforia;

public class CameraFocus : MonoBehaviour {

    void Start()
    {
        Vuforia.CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }

}
