using UnityEngine;
using Zenject;

public class GameDataInstaller : MonoInstaller
{
    [SerializeField]
    private InputButtonData _inputButtonData;

    public override void InstallBindings()
    {
        BindInputButtonData();
    }

    private void BindInputButtonData()
    {
        Container.Bind<InputButtonData>().FromInstance(_inputButtonData).AsSingle();
    }
}