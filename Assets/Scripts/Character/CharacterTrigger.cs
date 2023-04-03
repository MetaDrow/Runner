using UnityEngine;
using UnityEngine.SceneManagement;

internal class CharacterTrigger : MonoBehaviour 
{
    [SerializeField] UILoadManager _sceneLoadManager;
    [SerializeField] AbstractCharacter _character;

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player") && other.CompareTag("Finish"))
        {
            CountManager.instance.SaveScore();
            _sceneLoadManager.Trigger();
        }

        if (CompareTag("Player") && other.CompareTag("Faster") && _character._speed <= 18f)
        {
            _character._speed += 0.2f;
        }

        if (CompareTag("Player") && other.CompareTag("RightBoxImpact"))
        {
            _character._line++;
            _character.StrafeRightCalculation();
        }

        if (CompareTag("Player") && other.CompareTag("LeftBoxImpact"))
        {
            _character._line--;
            _character.StrafeLeftCalculation();
        }
    }
}
