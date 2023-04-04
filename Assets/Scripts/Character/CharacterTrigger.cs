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

        if (CompareTag("Player") && other.CompareTag("Faster") && _character._speed <= 19f)
        {
            _character._speed += 0.2f;
        }

        if (CompareTag("Player") && other.CompareTag("RightBoxImpact"))
        {
            int impactCount = 0;
            _character._line++;
            _character.StrafeRightCalculation();
            impactCount++;
            if(impactCount >1)
            {
                _sceneLoadManager.Trigger();
                impactCount = 0;
            }
        }

        if (CompareTag("Player") && other.CompareTag("LeftBoxImpact"))
        {
            int impactCount = 0;
            _character._line--;
            _character.StrafeLeftCalculation();
            impactCount++;
            if (impactCount > 1)
            {
                _sceneLoadManager.Trigger();
                impactCount = 0;
            }
        }
    }
}
