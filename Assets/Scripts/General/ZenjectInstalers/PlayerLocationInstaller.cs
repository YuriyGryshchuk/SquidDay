using UnityEngine;
using Zenject;

public class PlayerLocationInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _playerPrefab;

    public override void InstallBindings()
    {
        BindPlayer();
    }

    private void BindPlayer()
    {
        Squid player = Container.InstantiatePrefabForComponent<Squid>(_playerPrefab, Vector3.zero, Quaternion.identity, null);
        Container.Bind<Squid>().FromInstance(player).AsSingle().NonLazy();
    }
}