using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategoriesItemWidget : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text description;
    public TMP_Text songs;
    public Button button;
    
    public event Action OnClick;
    
    void Awake()
    {
        button.onClick.AddListener(HandleClick);
    }
    
    public void SetData(Category category)
    {
        title.text = category.category.title;
        description.text = category.category.description;
        songs.text = $"songs: {category.songs.Count}";
    }
    
    private void HandleClick()
    {
        OnClick?.Invoke();
    }
}
