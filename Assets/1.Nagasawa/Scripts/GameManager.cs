using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager
{
    #region �v���p�e�B
    /// <summary>
    /// GameManager�̃C���X�^���X
    /// </summary>
    public static GameManager Instance = new GameManager();

    /// <summary>
    /// �X�R�A
    /// </summary>
    public static int[] Score => _scores;

    /// <summary>
    /// ���݂̃Q�[���t�F�C�Y
    /// </summary>
    public static GamePhase CurrentGamePhase => _gamePhase;

    /// <summary>
    /// ���݂̃^�[��
    /// </summary>
    public static Turn CurrentTurn => _currentTurn;
    #endregion

    #region �ϐ�
    static int[] _scores = new int[2];
    static float _time;
    static GamePhase _gamePhase;
    static Turn _currentTurn;
    #endregion

    #region �C�x���g
    /// <summary>
    /// �Q�[���X�^�[�g���̃C�x���g
    /// </summary>
    public event Action OnStartGame;

    /// <summary>
    /// �Q�[���I�����̃C�x���g
    /// </summary>
    public event Action OnFinishGame;

    /// <summary>
    /// �^�[���`�F���W���̃C�x���g
    /// </summary>
    public event Action<Turn> OnChangeTurn;
    #endregion

    public void ResetGame()
    {
        ChangeGamePhase(GamePhase.GameReady);
        _scores[0] = 0;
        _scores[1] = 0;
        //���������_���ɂ��邩
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
            Debug.Log("�t�F�C�Y�ꏏ����");
            return;
        }

        _gamePhase = gamePhase;
        Debug.Log($"�Q�[���t�F�C�Y��{_gamePhase}");

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
            Debug.Log("�^�[���ꏏ����");
            return;
        }

        _currentTurn = turn;
        Debug.Log("�^�[���ς������");

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
