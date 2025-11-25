using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GameOver : MonoBehaviour
{
    public GameManager gameManager;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void RestartButton()
    {
        YG2.InterstitialAdvShow();
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void ContinueRewardButton()
    {
        YG2.InterstitialAdvShow();
        Time.timeScale = 1;
        //gameManager.SpawnSpaceShip();
        gameObject.SetActive(false);
    }
    public void ContinueButton()
    {
        YG2.RewardedAdvShow("1");
        //gameManager.SpawnSpaceShip();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void MenuButton()
    {
        YG2.InterstitialAdvShow();
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
