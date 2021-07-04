using Sirenix.OdinInspector;
using UnityEngine;

public abstract class SingletonScriptableObject<T> : SerializedScriptableObject where T : SingletonScriptableObject<T>
{
	static T _instance = null;
	
	public static T Instance
	{
		get
		{
			if(!_instance)
				_instance = Resources.Load<T>(typeof(T).Name);
			return _instance;
		}
	}
}
