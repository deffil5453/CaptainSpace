using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
public enum SoundType
{
    ShipAttack,
    PlayerDead,
    SupportPickup,
    EnemyDead,
    EnemyAttack,
    UIClick
    // добавл€й новые звуки сюда
}
[System.Serializable]
class AudioSound
{
    public AudioSource AudioSource;
    public SoundType SoundType;
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("«вуки дл€ игрока")]
    public AudioSource AudioSpaceShipAttack;
    public AudioSource AudioPlayerDead;
    [Header("«вуки подбора элементов поддержки")]
    public AudioSource AudioSupportTake;
    [Header("«вуки врага")]
    public AudioSource AudioEnemyDead;
    public AudioSource AudioEnemyAttack;
    [SerializeField] private AudioSound[] _audioSound;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            AudioSpaceShipAttack.Pause();
            AudioPlayerDead.Pause();
            AudioSupportTake.Pause();
            AudioEnemyDead.Pause();
            AudioEnemyAttack.Pause();
        }
        else
        {
            AudioSpaceShipAttack.UnPause();
            AudioPlayerDead.UnPause();
            AudioSupportTake.UnPause();
            AudioEnemyDead.UnPause();
            AudioEnemyAttack.UnPause();
        }
    }
    public void SpaceShipAttackAudio()
    {
        AudioSpaceShipAttack.PlayOneShot(AudioSpaceShipAttack.clip);
    }
    public void EnemyDeadAudio()
    {
        AudioEnemyDead.Play();
    }
    public void PlaySound(SoundType soundType)
    {
        foreach (var item in _audioSound)
        {
            if (item.SoundType== soundType)
            {
                item.AudioSource.PlayOneShot(item.AudioSource.clip);
            }
        }
        //if (soundType == _audioSound.SoundType)
        //{
        //    _audioSound.AudioSource.PlayOneShot(_audioSound.AudioSource.clip);
        //}
    }
}
