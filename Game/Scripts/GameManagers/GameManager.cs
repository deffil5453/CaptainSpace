using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
    private int _moneyGame;
    private int _totalMoneyGame;

    private int _selectIdShip;
    private GameObject _currentSpaceShip;

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
        _levelWafe = PlayerPrefs.GetInt("LevelWafe", 1);
        KillEnemyToWin = 6;
        //KillEnemyToWin = KillEnemyToWin *_levelWafe;
        KillEnemyToWin = (KillEnemyToWin * _levelWafe) / 2;
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
        _totalMoneyGame = PlayerPrefs.GetInt("PlayerMoney", 0);

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
        _levelWafe += 1;
        PlayerPrefs.SetInt("LevelWafe", _levelWafe);
        Time.timeScale = 0f;
        //Time.timeScale = 0;
    }
    private void AddMoney(int amount)
    {
        _moneyGame += amount;
        _totalMoneyGame += amount;
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
        //PlayerPrefs.SetInt("PlayerMoney", KillEnemyToWin);
        if (PlayerPrefs.GetInt("MaxScore", 0) < _score)
        {
            PlayerPrefs.SetInt("MaxScore", _score);
        }
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