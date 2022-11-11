using UnityEngine;
using Zenject;

public class GameConfigsInstaller : MonoInstaller
{
    [SerializeField]
    private PlayerConfig _playerConfig;

    public override void InstallBindings()
    {
        BindPlayerConfig();
    }

    private void BindPlayerConfig()
    {
        Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle();
    }
}