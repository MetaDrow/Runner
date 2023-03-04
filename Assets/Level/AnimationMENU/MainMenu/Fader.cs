using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{

    public Animator animator;

    private int levelToLoad;


    void Update()
    {
        

           // FadeToNextLevel();
    
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FaderOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}

