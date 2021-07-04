using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CategoriesListWidget categoriesWidget;
    void Start()
    {
        var categories = SongsManager.Instance.categories.Values.ToList();
        
        DumpCategories(categories);
        
        categoriesWidget.SetData(categories);
    }

    private static void DumpCategories(List<Category> categories)
    {
        foreach (var cat in categories)
        {
            Debug.Log($"Category: {cat.category.title}");
            foreach (var song in cat.songs)
            {
                Debug.Log($"Song: {song.title}");
            }
        }
    }
}
