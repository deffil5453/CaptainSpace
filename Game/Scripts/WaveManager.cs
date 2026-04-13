using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _textBlock;
    private int currentKill = 0;
    private int MaxKill = 1;
    private void Start()
    {
        GameManager.instance.OnEnemyKilled += UIUpdateWave;        
        MaxKill = GameManager.instance.KillEnemyToWin;
        if (YG2.lang == "ru")
        {
            _textBlock.text = $"убито {currentKill} " +
                $"из {MaxKill}";
        }
        else
        {
            _textBlock.text = $"killed {currentKill} of {MaxKill}";
        }
    }
    private void UIUpdateWave()
    {
        currentKill++;

        if (YG2.lang == "ru")
        {

            _textBlock.text = $"убито {currentKill} " +
                $"из {MaxKill}";
        }
        else
        {
            _textBlock.text = $"killed {currentKill} of {MaxKill}";
        }
        if (currentKill>= MaxKill)
        {
            GameManager.instance.PlayerWin();
            return;
        }


    }
    private void OnDestroy()
    {
        GameManager.instance.OnEnemyKilled -= UIUpdateWave;
    }
}
