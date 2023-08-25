using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator 
{
    SpriteRenderer spriteRenderer;
    float FrameRate;
    List<Sprite> FrameList;

    float Timer;
    int CurrentFrame;

    public SpriteAnimator(List<Sprite> FrameList, SpriteRenderer spriteRenderer, float FrameRate = 0.15f)
    {
        this.FrameList = FrameList;
        this.spriteRenderer = spriteRenderer;
        this.FrameRate = FrameRate;
    }
        
    public void Start()
    {
        CurrentFrame = 0;
        Timer = 0f;
        spriteRenderer.sprite = FrameList[0];
    }
    
    public void HandleUpdate()
    {
        Timer += Time.deltaTime;
        if(Timer > FrameRate)
        {
            CurrentFrame = (CurrentFrame + 1) % FrameList.Count;
            spriteRenderer.sprite = FrameList[CurrentFrame];
            //Timer -= FrameRate;
        }
    }
}
