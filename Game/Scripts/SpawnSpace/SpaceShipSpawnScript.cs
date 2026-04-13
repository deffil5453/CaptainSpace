using UnityEngine;
using UnityEngine.UI;

public class SpaceShipSpawnScript : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Image _healthBar;
    [SerializeField] private GameObject _gameObjectSpaceShip;
    [SerializeField] private Transform _spawnTransform;
    private void Start()
    {
        Spawn();
    }
    private void Spawn()
    {
        ShipModel shipModel = SaveShip.LoadShipData(_inventory.CurrentShip);
        _gameObjectSpaceShip = Instantiate(_inventory.CurrentShip.Prefab, _spawnTransform.position, Quaternion.identity);
        _gameObjectSpaceShip
            .GetComponent<ShipHealthSystem>()
            .Inizialize(shipModel.CurrentHealth);
        _gameObjectSpaceShip.GetComponent<ShipHealthSystem>().Bar = _healthBar;
        _gameObjectSpaceShip
            .GetComponent<ShipAttack>()
            .Inizialize(shipModel.CurrentAttack, shipModel.CurrentAttackSpeed);
        //_gameObjectSpaceShip.GetComponent<ShipControl>().Bar = _healthBar;
        //_gameObjectSpaceShip.GetComponent<ShipRun>().Inizialize(_inventory.CurrentShip.);
    }
    public void RewardShipInit()
    {
        _gameObjectSpaceShip.GetComponent<ShipHealthSystem>().SetFullHealth();
        _gameObjectSpaceShip.transform.position = _spawnTransform.position;
    }
}