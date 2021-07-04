using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategorySetup
{
    public string path;
    public string title;
    public string description;
}

[CreateAssetMenu(menuName = "Game Assets/Categories Settings", fileName="CategoriesSettings")]
public class CategoriesSettings : SingletonScriptableObject<CategoriesSettings>
{
    public List<CategorySetup> categories;
}
