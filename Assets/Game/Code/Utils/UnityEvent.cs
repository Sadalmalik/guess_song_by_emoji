using System;
using UnityEngine;

public class UnityEvent : MonoBehaviour
{
    private static UnityEvent instance_;

    private static event Action OnUpdate_;

    private static event Action OnFixedUpdate_;

    private static event Action OnLateUpdate_;

    private static event Action OnNextUpdate_;

    private static event Action<bool> OnApplicationFocusChanged_;
    
    private static event Action TempAction_;
    private static event Action<bool> TempBoolAction_;

    public static event Action OnUpdate
    {
        add { CheckInstance(); OnUpdate_ += value; }
        remove { CheckInstance(); OnUpdate_ -= value; }
    }

    public static event Action OnFixedUpdate
    {
        add { CheckInstance(); OnFixedUpdate_ += value; }
        remove { CheckInstance(); OnFixedUpdate_ -= value; }
    }

    public static event Action OnLateUpdate
    {
        add { CheckInstance(); OnLateUpdate_ += value; }
        remove { CheckInstance(); OnLateUpdate_ -= value; }
    }

    public static event Action OnNextUpdate
    {
        add { CheckInstance(); OnNextUpdate_ += value; }
        remove { CheckInstance(); OnNextUpdate_ -= value; }
    }

    public static event Action<bool> OnApplicationFocusChanged
    {
        add { CheckInstance(); OnApplicationFocusChanged_ += value; }
        remove { CheckInstance(); OnApplicationFocusChanged_ -= value; }
    }

    private static void CheckInstance()
    {
        if (instance_ == null)
        {
            GameObject o = new GameObject("UnityEvent");
            instance_ = o.AddComponent<UnityEvent>();
            GameObject.DontDestroyOnLoad(o);
        }
    }

    private void Start()
    {
        if (instance_ == null)
        {
            instance_ = this;
        }
        else
        {
            if (instance_ != this)
                this.enabled = false;
        }
    }

    private void Update()
    {
        SafeInvoke(OnUpdate_);
        SafeInvoke(OnNextUpdate_, true);
    }

    private void FixedUpdate()
    {
        SafeInvoke(OnFixedUpdate_);
    }

    private void LateUpdate()
    {
        SafeInvoke(OnLateUpdate_);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        SafeInvoke(OnApplicationFocusChanged_, hasFocus);
    }
    
    private void SafeInvoke(Action act, bool clear=false)
    {
        TempAction_ = act;
        OnNextUpdate_ = null;
        TempAction_?.Invoke();
        if (clear)
            TempAction_ = null;
    }
    
    private void SafeInvoke(Action<bool> act, bool value, bool clear=false)
    {
        TempBoolAction_ = act;
        OnNextUpdate_ = null;
        TempBoolAction_?.Invoke(value);
        if (clear)
            TempBoolAction_ = null;
    }
}
