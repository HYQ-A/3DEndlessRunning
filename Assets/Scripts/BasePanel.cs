using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BasePanel<T> : MonoBehaviour where T: class
{
    private static T instance;
    public static T Instance => instance;

    protected virtual void Awake()
    {
        instance = this as T;
    }

    private void Start()
    {
        Init();
    }

    public abstract void Init();

    /// <summary>
    /// �����������-virtual����������д
    /// </summary>
    public virtual void ShowMe()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// �����������-virtual����������д
    /// </summary>
    public virtual void HideMe()
    {
        this.gameObject.SetActive(false);
    }


}
