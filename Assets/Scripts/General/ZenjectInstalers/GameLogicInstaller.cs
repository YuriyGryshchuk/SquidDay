using UnityEngine;
using Zenject;

public class GameLogicInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _scoreConterPrefab;

    public override void InstallBindings()
    {
        BindScoreCounter();
    }

    private void BindScoreCounter()
    {
        Container.Bind<ScoreCouner>().FromComponentInNewPrefab(_scoreConterPrefab).AsSingle();
    }
}