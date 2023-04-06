using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : PoolableMono
{
    Stack<T> _pool = new Stack<T>();
    private T _prefab;
    private Transform _parentTransform;

    public Pool(T prefab, Transform parentTransform,int count)
    {
        _prefab = prefab;
        _parentTransform = parentTransform;
        for(int i = 0; i < count; i++)
        {
            T obj = GameObject.Instantiate(_prefab, _parentTransform);
            obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", "");
            obj.gameObject.SetActive(false);
            _pool.Push(obj);
        }
    }

    public T Pop()
    {
        T obj;
        if (_pool.Count > 0)
        {
            obj = _pool.Pop();
        }
        else
        {
            obj = GameObject.Instantiate(_prefab, _parentTransform);
            obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", "");
        }
        obj.gameObject.SetActive(true);
        return obj;

    }

    public void Push(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Push(obj);
    }
}
