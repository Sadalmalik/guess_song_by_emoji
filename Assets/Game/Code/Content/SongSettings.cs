using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Assets/Song Settings", fileName="SongSettings")]
public class SongSettings : SerializedScriptableObject
{
	public string title;
	public string author;
	[TextArea(3, 15)]
	public string emoji;
	[TextArea(3, 15)]
	public string guessText;
}
