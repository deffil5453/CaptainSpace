using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GameOver : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private SpaceShipSpawnScript _spaceShipSpawnScript;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        _spaceShipSpawnScript = FindObjectOfType<SpaceShipSpawnScript>();
    }
    public void RestartButton()
    {
        YG2.InterstitialAdvShow();
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void ContinueRewardButton()
    {
        YG2.RewardedAdvShow("1");
        Time.timeScale = 1;
        _spaceShipSpawnScript.RewardShipInit();
        gameObject.SetActive(false);
    }
    //public void ContinueButton()
    //{
    //    YG2.RewardedAdvShow("1");
    //    //gameManager.SpawnSpaceShip();
    //    Time.timeScale = 1;
    //    gameObject.SetActive(false);
    //}
    public void MenuButton()
    {
        YG2.InterstitialAdvShow();
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
