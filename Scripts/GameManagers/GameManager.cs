using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject PausePanel, GameOverPanel;
    [SerializeField] private Inventory _inventory;
    public Image PlayerHealthBar;
    public TMP_Text TextScore;

    private int _score;
    private int _moneyGame;
    private int _totalMoneyGame;

    private int _selectIdShip;
    private GameObject _currentSpaceShip;
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

    public void AddScore(int amount)
    {
        _score += amount;

        AddMoney(amount);
        UpdateTextScore();
    }
    public void AddMoney(int amount)
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
        PlayerPrefs.SetInt("PlayerMoney", _totalMoneyGame);
        if (PlayerPrefs.GetInt("MaxScore", 0) < _score)
        {
            PlayerPrefs.SetInt("MaxScore", _score);
        }
        PlayerPrefs.Save();
    }
    private void UpdateTextScore()
    {
        TextScore.text = _score.ToString();
    }
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