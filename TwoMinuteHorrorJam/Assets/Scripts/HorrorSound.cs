using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HorrorSound : HorrorObject
{
    /// <summary>
    /// 音效來源
    /// </summary>
    private AudioSource aud;

    [Header("音效")]
    public AudioClip sound;

    [Header("音量"), Range(0.1f, 10)]
    public float volume = 1;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 覆寫父類別觸發事件方法
    /// 播放音效
    /// </summary>
    public override void TriggerEvent()
    {
        aud.PlayOneShot(sound, volume);
    }
}
