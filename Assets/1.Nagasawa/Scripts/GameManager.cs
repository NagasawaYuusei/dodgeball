using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager
{
    #region プロパティ
    /// <summary>
    /// GameManagerのインスタンス
    /// </summary>
    public static GameManager Instance = new GameManager();

    /// <summary>
    /// スコア
    /// </summary>
    public static int[] Score => _scores;

    /// <summary>
    /// 現在のゲームフェイズ
    /// </summary>
    public static GamePhase CurrentGamePhase => _gamePhase;

    /// <summary>
    /// 現在のターン
    /// </summary>
    public static Turn CurrentTurn => _currentTurn;
    #endregion

    #region 変数
    static int[] _scores = new int[2];
    static float _time;
    static GamePhase _gamePhase;
    static Turn _currentTurn;
    #endregion

    #region イベント
    /// <summary>
    /// ゲームスタート時のイベント
    /// </summary>
    public event Action OnStartGame;

    /// <summary>
    /// ゲーム終了時のイベント
    /// </summary>
    public event Action OnFinishGame;

    /// <summary>
    /// ターンチェンジ時のイベント
    /// </summary>
    public event Action<Turn> OnChangeTurn;
    #endregion

    public void ResetGame()
    {
        ChangeGamePhase(GamePhase.GameReady);
        _scores[0] = 0;
        _scores[1] = 0;
        //ここランダムにするか
        _currentTurn = Turn.Player1;
    }

    public void AddScore(int score)
    {
        _scores[(int)CurrentTurn] += score;
    }

    public void ChangeGamePhase(GamePhase gamePhase)
    {
        if(gamePhase == _gamePhase)
        {
            Debug.Log("フェイズ一緒だお");
            return;
        }

        _gamePhase = gamePhase;
        Debug.Log($"ゲームフェイズは{_gamePhase}");

        switch (_gamePhase)
        {
            case GamePhase.InGame:
                OnStartGame.Invoke();
                break;
            case GamePhase.GameFinish:
                OnFinishGame.Invoke();
                break;
            default:
                break;
        }
    }

    public void TurnChange(Turn turn)
    {
        if (turn == _currentTurn)
        {
            Debug.Log("ターン一緒だお");
            return;
        }

        _currentTurn = turn;
        Debug.Log("ターン変わったよ");

        OnChangeTurn.Invoke(_currentTurn);
    }


    public enum GamePhase
    {
        GameReady,
        InGame,
        GameFinish
    }

    public enum Turn
    {
        Player1 = 0,
        Player2 = 1,
    }
}
