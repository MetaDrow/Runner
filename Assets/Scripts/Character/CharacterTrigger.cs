using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

internal class CharacterTrigger : MonoBehaviour 
{
    [SerializeField] SceneLoadManager _sceneLoadManager;
    [SerializeField] AbstractCharacterMove _character;
    void Update()
    {
        RestartGame();

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
            _sceneLoadManager.Trigger();

        }

        if (CompareTag("Player") && other.CompareTag("Faster"))
        {
            _character._speed += 0.2f;
        }

    }





}
