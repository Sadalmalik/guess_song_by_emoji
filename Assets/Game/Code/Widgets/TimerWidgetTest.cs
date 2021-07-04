using System;
using UnityEngine;

public class TimerWidgetTest : MonoBehaviour
{
	public TimerWidget target;
	[Space]
	public float duration;
	[Space]
	public bool start;
	public bool stop;
	public bool pause;
	public bool resume;

	private UnityTimer _timer;

	private void Trigger(ref bool flag, Action act)
	{
		if (flag) { flag = false; act?.Invoke(); }
	}

	void Update()
	{
		Trigger(ref start, StartTimer);
		Trigger(ref stop, StopTimer);
		Trigger(ref pause, PauseTimer);
		Trigger(ref resume, ResumeTimer);
	}

	void StartTimer()
	{
		_timer?.Stop();
		
		_timer = new UnityTimer(duration);
		
		target.SetTimer(_timer);
	}

	void StopTimer()
	{
		_timer.Stop();
	}

	void PauseTimer()
	{
		_timer.Pause();
	}

	void ResumeTimer()
	{
		_timer.Resume();
	}
}