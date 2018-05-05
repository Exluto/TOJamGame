﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public StateManager m_stateManager;
	public GameState m_currentState;
	public StateGameIntro m_stateGameIntro { get; set; }
	public StateGameMenu m_stateGameMenu { get; set; }
	public StateGamePlay m_stateGamePlay { get; set; }
	public static GameManager Instance { get{ return m_instance; } }

	private static GameManager m_instance = null;



void Awake() {
		if(m_instance != null && m_instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			m_instance = this;
		}
		DontDestroyOnLoad(this.gameObject);

		m_stateGameIntro = new StateGameIntro(this);
		m_stateGameMenu = new StateGameMenu(this);
		m_stateGamePlay = new StateGamePlay(this);
	}

	public void StartGame() {
		NewGameState(m_stateGameIntro);
	}

	private void Update() {
		if(m_currentState != null) {
			m_currentState.Execute();
		}
	}

	public void NewGameState(GameState newState) {
		if(m_currentState != null) {
			m_currentState.Exit();
		}
		m_currentState = newState;
		m_currentState.Enter();
	}

	public void UpdateFSM(GameStates newState) {
		m_stateManager.ChangeState(newState);
	}
}