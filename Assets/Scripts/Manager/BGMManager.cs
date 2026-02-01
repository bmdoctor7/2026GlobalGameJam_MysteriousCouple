using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : SingletonMonoBase<BGMManager>
{
    public AudioSource audioSource;
    public AudioClip bgmClip;

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // 切场景不销毁

        if (!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
            if (!audioSource)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        if (bgmClip)
        {
            audioSource.clip = bgmClip;
            audioSource.loop = true;   // 循环播放
            audioSource.Play();
        }
    }

    // 可选：对外提供换 BGM 的方法
    public void PlayBGM(AudioClip clip)
    {
        if (clip == null) return;
        bgmClip = clip;
        audioSource.clip = bgmClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

    public void SetVolume(float value)
    {
        audioSource.volume = Mathf.Clamp01(value);
    }
}
