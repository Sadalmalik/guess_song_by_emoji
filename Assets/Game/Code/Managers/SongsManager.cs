using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Category
{
	public CategorySetup category;
	public List<SongSettings> songs;
}

public class SongsManager
{
	private static SongsManager _instance;

	public static SongsManager Instance
	{
		get
		{
			if (_instance == null)
				_instance = new SongsManager();
			return _instance;
		}
	}

	public readonly Dictionary<string, Category> categories;

	private SongsManager()
	{
		categories = new Dictionary<string, Category>();

		foreach (var category in CategoriesSettings.Instance.categories)
		{
			categories.Add(
				category.path,
				new Category
				{
					category = category,
					songs    = Resources.LoadAll<SongSettings>(category.path).ToList()
				});
		}
	}
}