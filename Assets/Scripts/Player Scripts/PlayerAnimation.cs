using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animation animation;
    // Start is called before the first frame update
    void Awake()
    {
        animation = GetComponent<Animation>();
    }

    public void Jumped()
    {
        animation.Play(Tags.ANIMATION_JUMP);
        Landed();
      
    }

    public void Landed()
    {
        animation.Stop(Tags.ANIMATION_JUMP);
        animation.Blend(Tags.ANIMATION_JUMP, 0);
        animation.CrossFade(Tags.ANIMATION_RUN);
    }

    public void Run()
    {
        animation.Play(Tags.ANIMATION_RUN);
    }

    public void Go()
    {
        animation.Play(Tags.ANIMATION_GO);
    }

    public void GoBack()
    {
        animation.Play(Tags.ANIMATION_GO_BACK);
    }

    public void RunLeft()
    {
        animation.Play(Tags.ANIMATION_RUN_LEFT);
    }

    public void Stop()
    {
        animation.Stop();
    }
}
