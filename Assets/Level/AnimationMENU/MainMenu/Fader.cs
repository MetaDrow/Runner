using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{

    public Animator _animator;

    private int levelToLoad;




    public void FadeToNextLevel()
    {
         FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void FadeToLevel(int levelIndex)
    {

        levelToLoad = levelIndex;
        _animator.SetTrigger("FaderOut");

    }
    
    public void OnFadeComplete() //this method use animator events
    {
        SceneManager.LoadScene(levelToLoad);
    }
    
}

