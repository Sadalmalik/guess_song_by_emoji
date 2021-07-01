using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Assets/SongSettings", fileName="SongSettings")]
public class SongSettings : ScriptableObject
{
	public string title;
	public string author;
	[TextArea(3, 15)]
	public string emoji;
	[TextArea(3, 15)]
	public string guessText;
}
