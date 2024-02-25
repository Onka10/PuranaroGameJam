using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public IReadOnlyReactiveProperty<GamePhase> Phase => _state;
    private readonly ReactiveProperty<GamePhase> _state = new ReactiveProperty<GamePhase>(global::GamePhase.Title);


    public void NextPhase()
    {
        _state.Value++;
    }

    public void ReTry()
    {
        _state.Value = GamePhase.Load;
    }

}


public enum GamePhase
{
    Title,
    Load,
    InGame,
    Result
}