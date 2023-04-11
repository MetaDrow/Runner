using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class CharacterTrigger : MonoBehaviour 
{
    [SerializeField] UILoadManager _sceneLoadManager;
    [SerializeField] AbstractCharacter _character;

    private int _rightImpactCount;
    private int _leftImpactCount;

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player") && other.CompareTag("Finish"))
        {
            PlayerPrefs.SetInt("SaveScore", CountManager.instance.hightScore);
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
            _rightImpactCount ++;

            if(_rightImpactCount >2)
            {
                PlayerPrefs.SetInt("SaveScore", CountManager.instance.hightScore);
                _sceneLoadManager.Trigger();
                _rightImpactCount = 0;
            }
            StartCoroutine(ImpactCountReset());
        }

        if (CompareTag("Player") && other.CompareTag("LeftBoxImpact"))
        {
            _character._line--;
            _character.StrafeLeftCalculation();
            _leftImpactCount++;

            if (_leftImpactCount > 2)
            {
                PlayerPrefs.SetInt("SaveScore", CountManager.instance.hightScore);
                _sceneLoadManager.Trigger();
                _leftImpactCount = 0;
            }
            StartCoroutine(ImpactCountReset());
        }

        IEnumerator ImpactCountReset()
        {

            yield return new WaitForSeconds(3f);
            _leftImpactCount = 0;
            _rightImpactCount= 0;
        }
    }
}
