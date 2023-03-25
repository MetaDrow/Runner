using System.Collections;
using System.Collections.Generic;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseUI.SetActive(false);
            _uiLoadManager.ResumeGame();
            _uiLoadManager._character._isPlay = true;

        }
    }
}
