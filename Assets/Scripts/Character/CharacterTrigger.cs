using UnityEngine;
using UnityEngine.SceneManagement;

internal class CharacterTrigger : MonoBehaviour 
{
    [SerializeField] UILoadManager _sceneLoadManager;
    [SerializeField] AbstractCharacter _character;
    private int _inmapctCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player") && other.CompareTag("Finish"))
        {
            CountManager.instance.SaveScore();
            _sceneLoadManager.Trigger();
            _inmapctCount = 0;
        }

        if (CompareTag("Player") && other.CompareTag("Faster") && _character._speed <= 19f)
        {
            _character._speed += 0.2f;
        }

        if (CompareTag("Player") && other.CompareTag("RightBoxImpact"))
        {
            _character._line++;

            _character.StrafeRightCalculation();
            _inmapctCount++;
            if(_inmapctCount >1)
            {
                _sceneLoadManager.Trigger();
                _inmapctCount = 0;
            }
        }

        if (CompareTag("Player") && other.CompareTag("LeftBoxImpact"))
        {
            _character._line--;
            _character.StrafeLeftCalculation();
            _inmapctCount++;
            if (_inmapctCount > 1)
            {
                _sceneLoadManager.Trigger();
                _inmapctCount = 0;
            }
        }
    }
}
