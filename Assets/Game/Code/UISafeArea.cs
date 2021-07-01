using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(RectTransform))]
public class UISafeArea : MonoBehaviour
{
	public bool ConformX = true;
	public bool ConformY = true;

	private RectTransform panel;
	private ScreenOrientation screenOrientation = ScreenOrientation.Unknown;
	private readonly List<ScreenOrientation> availableOrientations = new List<ScreenOrientation>
	{
		ScreenOrientation.Portrait,
		ScreenOrientation.PortraitUpsideDown
	};

	private void Awake()
	{
		panel = GetComponent<RectTransform>();

		if (ChechSafeArea())
			SpecialChangeSafeArea();

		screenOrientation = Screen.orientation;
	}


	private void Update()
	{
		ScreenOrientation newScreenOrientation = Screen.orientation;

		if (screenOrientation != newScreenOrientation && availableOrientations.Contains(newScreenOrientation))
		{
			screenOrientation = newScreenOrientation;

			if (ChechSafeArea())
				SpecialChangeSafeArea();
		}
	}

	private bool ChechSafeArea()
	{
		return Screen.width != Screen.safeArea.width || Screen.height != Screen.safeArea.height;
	}

	private void ApplySafeArea(Rect safeArea)
	{
		if (!ConformX)
		{
			safeArea.x     = 0;
			safeArea.width = Screen.width;
		}

		if (!ConformY)
		{
			safeArea.y      = 0;
			safeArea.height = Screen.height;
		}

		Vector2 anchorMin = safeArea.position;
		Vector2 anchorMax = safeArea.position + safeArea.size;
		anchorMin.x /= Screen.width;
		anchorMin.y /= Screen.height;
		anchorMax.x /= Screen.width;
		anchorMax.y /= Screen.height;

		panel.anchorMin = anchorMin;
		panel.anchorMax = anchorMax;
	}


	private void SpecialChangeSafeArea()
	{
		ApplySafeArea(Screen.safeArea);

		Vector2 anchorMin = panel.anchorMin;
		Vector2 anchorMax = panel.anchorMax;

		anchorMin.x = (anchorMin.x * 2.0f) / 3.0f;
		anchorMin.y = (anchorMin.y * 2.0f) / 3.0f;

		anchorMax.x = 1 - (1 - anchorMax.x) * 2.0f / 3.0f;
		anchorMax.y = 1 - (1 - anchorMax.y) * 2.0f / 3.0f;

		panel.anchorMin = anchorMin;
		panel.anchorMax = anchorMax;
	}
}