using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

internal class Restart : MonoBehaviour
{
    public DeathMenu _DeathMenu;
    public AbstractCharacterMove _character;
    public PlatformFactory _platform;
    public BasePrefab _prefab;
    // Это заглушка для тестов


    void Update()
    {
        RestartGame();
        Ray();
    }

    private void RestartGame()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player") && other.CompareTag("Finish"))
        {
            // Invoke("DeathPanel", 1f);
            // _DeathMenu._fader.animator.SetTrigger("FaderOut");
            _character._isPlay = false;
            _character._animator.Play("Death");
            //_character._rb.transform.position = new Vector3(0, _character._rb.position.y, _character._rb.position.z);

           // var platformPosition = _platformGenerate.PlatformSpawned.position;
            PauseGame();
            StartCoroutine(DeathPanel());




        }

        if (CompareTag("Player") && other.CompareTag("Faster"))
        {
            _prefab._speed += 20f;
        }
    }
    void Ray()
    {
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = Vector3.down;
        Debug.DrawRay(transform.position, Vector3.down);

    }
    IEnumerator DeathPanel()
    {

        yield return new WaitForSecondsRealtime(2f);
        this._character.transform.position = _platform.PrefabSpawned[2].transform.position;
        this._character._line = 0;
        _DeathMenu.deathPanel.SetActive(true);
        _character._isPlay = true;
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
    private void Reset()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
