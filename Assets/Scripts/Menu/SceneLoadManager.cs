using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.TextCore.Text;

internal class SceneLoadManager : MonoBehaviour
{
    public AbstractCharacterMove _character;
    public PlatformFactory _platform;
    public DeathMenu _DeathMenu;


    internal void Trigger()
    {

        _character._isPlay = false;

        _character._animator.Play("Death");

        PauseGame();
        _DeathMenu._audio.Pause();
        StartCoroutine(DeathPanel());

    }

    IEnumerator DeathPanel()
    {

        yield return new WaitForSecondsRealtime(2f);
        this._character.transform.position = _platform.PrefabSpawned[2].transform.position;
        this._character._line = 0;
        this._character._targetPos = this._character._rb.transform.position;
        ScoreManager.instance._gameUI.SetActive(false);

        _DeathMenu.deathPanel.SetActive(true);
        _character._isPlay = true;
    }



    void PauseGame()
    {
        Time.timeScale = 0;
    }
}
