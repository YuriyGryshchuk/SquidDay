using UnityEngine;
using Zenject;

public class PlayerLocationInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _playerPrefab;

    public override void InstallBindings()
    {
        BindPlayerHealth();
    }

    private void BindPlayerHealth()
    {
        PlayerHealth player = Container.InstantiatePrefabForComponent<PlayerHealth>(_playerPrefab, Vector3.zero, Quaternion.identity, null);
        Container.Bind<PlayerHealth>().FromInstance(player).AsSingle().NonLazy();
    }
}