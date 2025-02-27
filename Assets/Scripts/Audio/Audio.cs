using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    private static Audio instance;
    public static Audio Instance => instance;

    // �������ֵ�AudioSource
    private AudioSource bgmAudioSource;
    // ��Ч��AudioSource
    private AudioSource sfxAudioSource;

    // �������ּ����б�
    public List<AudioClip> bgmClipList = new List<AudioClip>();
    // ��Ч�����б�
    public List<AudioClip> sfxClipList = new List<AudioClip>();

    private int bgmClipID = 0;
    private Coroutine coroutine;

    private void Awake()
    {
        if (Audio.Instance != null)
        {
            Destroy(Audio.Instance.gameObject);
        }
        instance = this;

        // ��ȡ�������ֺ���Ч��AudioSource���
        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        sfxAudioSource = gameObject.AddComponent<AudioSource>();

        SetMusicValue(GameData.Instance.MusicData.musicVal);
    }

    private void Start()
    {
        ChangeMusic(bgmClipID);
        LoopMusic();
        DontDestroyOnLoad(gameObject);
    }

    public void LoopMusic()
    {
        bgmAudioSource.loop = true;
    }

    public void SetMusicValue(float value)
    {
        bgmAudioSource.volume = value;
    }

    public void ChangeMusic(int id)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(ChangeClip(id));
    }

    private IEnumerator ChangeClip(int id)
    {
        bgmClipID = id;
        bgmAudioSource.mute = true;
        yield return new WaitForSeconds(0.1f);
        bgmAudioSource.mute = false;
        bgmAudioSource.clip = bgmClipList[bgmClipID];
        bgmAudioSource.Play();
    }

    public void PlaySFX(int sfxID)
    {
        if (sfxID >= 0 && sfxID < sfxClipList.Count)
        {
            sfxAudioSource.PlayOneShot(sfxClipList[sfxID]);
        }
    }
    public void SetSoundValue(float value)
    {
        sfxAudioSource.volume = value;
    }
}