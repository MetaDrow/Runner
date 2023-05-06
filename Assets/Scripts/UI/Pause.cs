using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] internal GameObject _pauseUI;
    [SerializeField] internal UILoadManager _uiLoadManager;

    void Start()
    {
        _pauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))// && UILoadManager._onPause == true)
        {
            _pauseUI.SetActive(false);
            _uiLoadManager.ResumeGame();
            _uiLoadManager._character._isPlay = true;
            UILoadManager._onPause = false;
        }
    }
}
