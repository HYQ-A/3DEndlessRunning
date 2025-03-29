using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 面板基类
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
    /// 控制面板显隐-virtual方便子类重写
    /// </summary>
    public virtual void ShowMe()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// 控制面板显隐-virtual方便子类重写
    /// </summary>
    public virtual void HideMe()
    {
        this.gameObject.SetActive(false);
    }


}
