using UnityEngine;

public class FrameRate : MonoBehaviour
{
    //for test
    public int _targetFrameRate = 60;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = _targetFrameRate;
    }
}
