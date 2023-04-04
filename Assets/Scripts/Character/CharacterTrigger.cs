using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class CharacterTrigger : MonoBehaviour 
{
    [SerializeField] UILoadManager _sceneLoadManager;
    [SerializeField] AbstractCharacter _character;

    private int _rightImpact;
    private int _leftImpact;

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

            _character._line++;
            _character.StrafeRightCalculation();
            _rightImpact ++;
            if(_rightImpact >2)
            {
                _sceneLoadManager.Trigger();
                _rightImpact = 0;
            }
            StartCoroutine(ImpactCountReset());
        }

        if (CompareTag("Player") && other.CompareTag("LeftBoxImpact"))
        {

            _character._line--;
            _character.StrafeLeftCalculation();
            _leftImpact++;


            if (_leftImpact > 2)
            {
                _sceneLoadManager.Trigger();
                _leftImpact = 0;

            }

            StartCoroutine(ImpactCountReset());

        }

        IEnumerator ImpactCountReset()
        {

            yield return new WaitForSeconds(3f);
            _leftImpact = 0;
            _rightImpact= 0;
        }
    }
}
