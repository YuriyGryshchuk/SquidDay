using UnityEngine;
using Zenject;

public class GameLogicInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _scoreConterPrefab;
    [SerializeField]
    private DifficultyChanger _difficultyChangerPrefab;

    public override void InstallBindings()
    {
        BindScoreCounter();
        BindDifficultyChanger();
    }

    private void BindScoreCounter()
    {
        Container.Bind<ScoreCouner>().FromComponentInNewPrefab(_scoreConterPrefab).AsSingle();
    }

    private void BindDifficultyChanger()
    {
        Container.Bind<DifficultyChanger>().FromComponentInNewPrefab(_difficultyChangerPrefab).AsSingle().NonLazy();
    }
}