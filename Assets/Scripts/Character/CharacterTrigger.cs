using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

internal class CharacterTrigger : MonoBehaviour 
{
    [SerializeField] UILoadManager _sceneLoadManager;
    [SerializeField] AbstractCharacter _character;
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
            CountManager.instance.SaveScore();
            _sceneLoadManager.Trigger();

        }

        if (CompareTag("Player") && other.CompareTag("Faster") && _character._speed <= 15f)
        {
            _character._speed += 0.2f;
        }

        if (CompareTag("Player") && other.CompareTag("RightBoxImpact"))
        {
            _character._line++;
            // _character._rb.velocity = _character._targetPos;
            _character.StrafeRightCalculation();
            //_character._rb.velocity += new Vector3(-2, 2, 0);
        }

        if (CompareTag("Player") && other.CompareTag("LeftBoxImpact"))
        {
            _character._line--;
            // _character._rb.velocity = _character._targetPos;
            _character.StrafeLeftCalculation();
            //_character._rb.velocity += new Vector3(-2, 2, 0);
        }
    }





}
