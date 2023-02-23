using System.Collections;
using UnityEngine;

public class LampAnimation : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private float _time = 0f;
    [SerializeField] private AnimationClip _animation;

    void Start()
    {
       _anim = GetComponent<Animator>();
        StartCoroutine(AnimationStart());

    }

    void LampAnim()
    {
        _anim.Play(_animation.name);

    }

    private IEnumerator AnimationStart()
    {
        yield return new WaitForSeconds(_time);
        LampAnim();
    }
}
