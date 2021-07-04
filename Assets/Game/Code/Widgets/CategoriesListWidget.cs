using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoriesListWidget : MonoBehaviour
{
    public CategoriesItemWidget prefab;
    public RectTransform listRect;
    
    public List<CategoriesItemWidget> categoriesItems;
    
    public void SetData(List<Category> categories)
    {
        foreach (var category in categories)
        {
            var categoryItem = Instantiate(prefab, listRect);
            categoryItem.SetData(category);
            categoriesItems.Add(categoryItem);
        }
    }
}
