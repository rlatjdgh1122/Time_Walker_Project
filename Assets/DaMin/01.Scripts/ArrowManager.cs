using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    [SerializeField] private Transform _playerPos;
    [SerializeField] private Vector3 _arrowOffset;
    private Transform _currentTarget;
    [SerializeField] private GameObject _Tartget;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _playerPos.position + _arrowOffset;

        if (_currentTarget != null)
            transform.LookAt(_currentTarget, Vector3.up);
    }

    public void SetArrowTargetAsName(string _targetname) => _currentTarget = GameObject.Find(_targetname).transform;

    public void SetArrowTargetAsVector(Vector3 _targetPos)
    {
        _Tartget.transform.position = _targetPos;
        _currentTarget = _Tartget.transform;
    }

    public void SetArrowTargetAsObject(GameObject _targetObj) => _currentTarget = _targetObj.transform;
}
