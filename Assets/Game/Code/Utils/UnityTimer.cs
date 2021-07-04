using System;
using System.Collections.Generic;
using UnityEngine;

public class UnityTimer
{
	public float duration;
	public bool loop;

	private bool _active;
	private float _endTime;
	private float _lastTime;

	public event Action OnElapsed;
	public event Action OnComplete;

	public bool IsActive => _active;
	public float timeLeft => Time.time < _endTime ? _endTime - Time.time : 0;
	public float timePassed => duration - timeLeft;

	public UnityTimer(float duration, bool loop = false, bool start = true)
	{
		this.duration = duration;
		this.loop     = loop;
		
		if (start)
			Start();
	}

	public void Start()
	{
		_active  = true;
		_endTime = Time.time + duration;

		UnityEvent.OnUpdate += HandleUpdate;
	}

	public void Stop()
	{
		_endTime = 0;
		_active  = false;

		UnityEvent.OnUpdate -= HandleUpdate;
	}

	public void Pause()
	{
		_active   = false;
		_lastTime = Time.time;

		UnityEvent.OnUpdate -= HandleUpdate;
	}

	public void Resume()
	{
		_active  =  true;
		_endTime += Time.time - _lastTime;

		UnityEvent.OnUpdate += HandleUpdate;
	}

	private void HandleUpdate()
	{
		if (!_active)
			return;
		float time = Time.time;
		if (_endTime < time)
		{
			if (loop)
			{
				OnElapsed?.Invoke();
				_endTime += duration;
			}
			else
			{
				OnComplete?.Invoke();
			}
		}
	}
}