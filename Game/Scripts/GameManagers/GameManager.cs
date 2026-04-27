using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using PlayerPrefs = RedefineYG.PlayerPrefs;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject PausePanel, GameOverPanel;
    [SerializeField] private Inventory _inventory;
    public UnityEngine.UI.Image PlayerHealthBar;
    //public TMP_Text TextScore;
    private int _levelWafe = 0;
    [SerializeField] private int _currentEnemyKill;
    public int KillEnemyToWin = 10;

    private int _score;
    private int _totalMoneyGame;

    public event Action OnEnemyKilled;
    public event Action OnGameWin;
    public GameObject WinPanel;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        KillEnemyToWin = 7;
        //KillEnemyToWin = KillEnemyToWin *_levelWafe;
        //Debug.Log(KillEnemyToWin);
        //Debug.Log(_levelWafe);
    }
    public int GetMoneyPlayer()
    {
        return _totalMoneyGame;
    }
    private void Start()
    {
        LoadGameData();
    }

    private void LoadGameData()
    {
        //SpawnSpaceShip();
        _levelWafe = PlayerPrefs.GetInt("LevelWafe");
        _totalMoneyGame = PlayerPrefs.GetInt("PlayerMoney", 0);
        KillEnemyToWin = (KillEnemyToWin * _levelWafe) / 2;

    }

    public void AddEnemyKill()
    {
        _score++;
        OnEnemyKilled?.Invoke();
    }
    public void PlayerWin()
    {
        OnGameWin?.Invoke();
        WinPanel.SetActive(true);
        Debug.Log("отработал");
        
        SaveGameData();
        Time.timeScale = 0f;
        //Time.timeScale = 0;
    }

    public void PlayerDead()
    {
        SaveGameData();
        Time.timeScale = 0;
        //_currentSpaceShip.SetActive(false);
        GameOverPanel.SetActive(true);
    }
    private void SaveGameData()
    {
        int oldscore = PlayerPrefs.GetInt("MaxScore");
        //PlayerPrefs.SetInt("PlayerMoney", KillEnemyToWin);
        _levelWafe += 1;
        Debug.Log(_levelWafe);
        PlayerPrefs.SetInt("LevelWafe", _levelWafe);
        Debug.Log($"сохранил {_levelWafe}");
        PlayerPrefs.Save();
        Debug.Log(_score + oldscore);
        PlayerPrefs.SetInt("MaxScore", _score + oldscore);

        PlayerPrefs.Save();
    }
    //private void UpdateTextScore()
    //{
    //    TextScore.text = _score.ToString();
    //}
    public void SpawnSpaceShip()
    {

        //if (_currentSpaceShip != null)
        //{
        //    Destroy(_currentSpaceShip);
        //}
        //foreach (var item in SpaceShip)
        //{
        //    _selectIdShip = PlayerPrefs.GetInt("IsSelected", 0);
        //}
        //Debug.Log(_selectIdShip);
        ////Instantiate(_inventory.CurrentShipPrefab);
        //_currentSpaceShip = Instantiate(_inventory.CurrentShipPrefab, new Vector3(0.5f, -3, 0f), Quaternion.identity);

        //PlayerHealthBar.fillAmount = 1.0f;
        //_currentSpaceShip.GetComponent<ShipControl>().GameManager = this;
        //_currentSpaceShip.GetComponent<ShipControl>().Bar = PlayerHealthBar;
    }
}