using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Звуки для игрока")]
    public AudioSource AudioSpaceShipAttack;
    public AudioSource AudioPlayerDead;
    [Header("Звуки подбора элементов поддержки")]
    public AudioSource AudioSupportTake;
    [Header("Звуки врага")]
    public AudioSource AudioEnemyDead;
    public AudioSource AudioEnemyAttack;
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
        AudioSpaceShipAttack.Play();    
    }
    public void EnemyDeadAudio()
    {
        AudioEnemyDead.Play();
    }
}
