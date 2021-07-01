using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerWidget : MonoBehaviour
{
	public TMP_Text text;
	public Image progressBar;
	public Gradient progressGradient;

	public float duration;

	private float endTime;

	public bool startTimer;
	public bool timerIsActive;
	
	public float remains;
	public float progress;
	
	void Update()
	{
		if (startTimer)
		{
			startTimer = false;
			StartTimer();
		}
		UpdateTime();
	}

	private void StartTimer()
	{
		endTime = Time.time + duration;
		timerIsActive = true;
	}

	private void UpdateTime()
	{
		if (!timerIsActive)
			return;
		
		var time = Time.time;
		if (time < endTime)
		{
			UpdayeProgress(endTime - time);
		}
		else
		{
			timerIsActive = false;
			UpdayeProgress(0);
		}
	}
	
	private void UpdayeProgress(float remains)
	{
		progress = remains / duration;
		
		progressBar.color = progressGradient.Evaluate(progress);
		progressBar.fillAmount = progress;
		
		text.text = remains > 60 ?
			$"{(int)(remains/60)}:{(int)(remains%60):00}" :
			$"{(int)(remains%60):00}:{(int)(100*(remains%1)):000}";
	}
}