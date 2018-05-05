﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {

	public Canvas m_questCanvas;
	public Text m_questTitle;
	public Text m_questSummary;
	public Text m_questExp;
	public GameObject m_buttonAccept;
	public GameObject m_buttonComplete;
	

	public void SetQuestText(string questTitle, string questSummary, string questExp) {
		m_questTitle.text = questTitle;
		m_questSummary.text = questSummary;
		m_questExp.text = questExp;
	}

	public void ChangeQuestIndicator(GameObject newQuest, GameObject questAccepted, GameObject questComplete, int amtToCompleteQuest, int currProgress) {
		if(newQuest.activeSelf) {
			newQuest.SetActive(false);
			questAccepted.SetActive(true);
		}
		if(currProgress >= amtToCompleteQuest) {
			questAccepted.SetActive(false);
			questComplete.SetActive(true);
			m_buttonComplete.SetActive(true);
			m_buttonAccept.SetActive(false);
		}
	}
}