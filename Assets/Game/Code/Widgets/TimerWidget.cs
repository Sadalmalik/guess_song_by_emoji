using System;
using System.Linq;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TimerWidgetInterval
{
	[HorizontalGroup]
	[LabelWidth(90)]
	[LabelText("Time / Format:")]
	public float time;
	[HorizontalGroup]
	[HideLabel]
	public string format;
}

public class TimerWidget : SerializedMonoBehaviour
{
	public TMP_Text text;
	public Image progressBar;
	public Gradient progressGradient;
	public bool countdown = true;
	public TimerWidgetInterval[] intervals;
	
	private UnityTimer _timer;

	public void SetTimer(UnityTimer timer)
	{
		_timer = timer;
	}

	void Update()
	{
		if (_timer==null || !_timer.IsActive)
			return;
		UpdayeProgress();
	}
	
	private void UpdayeProgress()
	{
		float time = countdown ? _timer.timeLeft : _timer.timePassed;
		float progress = time / _timer.duration;
		
		progressBar.color = progressGradient.Evaluate(progress);
		progressBar.fillAmount = progress;
		
		TimeSpan span = new TimeSpan(0,0,0,0,(int)(time * 1000));
		
		text.text = span.ToString(GetFormatForTime(time));
		
		// text.text = time > 60 ?
		// 	$"{(int)(time/60)}:{(int)(time%60):00}" :
		// 	$"{(int)(time%60):00}.{(int)(100*(time%1)):000}";
	}
	
	private string GetFormatForTime(float time)
	{
		foreach (var interval in intervals)
		{
			if (time<interval.time)
			{
				return interval.format;
			}
		}
		return intervals.Last().format;
	}
}