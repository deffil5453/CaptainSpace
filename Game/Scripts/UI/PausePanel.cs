using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class PausePanel : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0f;
    }
    public void RestartButton()
    {
        YG2.InterstitialAdvShow();
        SceneManager.LoadScene("Game");
        Time.timeScale = 1.0f;
    }
    public void ContinueButton()
    {
        YG2.InterstitialAdvShow();
        //gameManager.SpawnSpaceShip();
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    public void MenuButton()
    {
        YG2.InterstitialAdvShow();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }
}
