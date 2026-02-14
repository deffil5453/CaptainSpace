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
        _gameObjectSpaceShip = Instantiate(_inventory.CurrentShip.Prefab, _spawnTransform.position, Quaternion.identity);
        _gameObjectSpaceShip
            .GetComponent<ShipHealthSystem>()
            .Inizialize(_inventory.CurrentShip.BaseHealth);
        _gameObjectSpaceShip
            .GetComponent<ShipAttack>()
            .Inizialize(_inventory.CurrentShip.BaseAttack, _inventory.CurrentShip.BaseAttackSpeed);
        _gameObjectSpaceShip.GetComponent<ShipControl>().Bar = _healthBar;
        //_gameObjectSpaceShip.GetComponent<ShipRun>().Inizialize(_inventory.CurrentShip.);
    }
}