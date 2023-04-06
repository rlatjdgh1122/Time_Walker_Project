using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownManager
{
    private Dictionary<string, float> _coolDowns = new Dictionary<string, float>();

    public bool IsCooldown(string key)
    {
        float coolDown;
        if (_coolDowns.TryGetValue(key, out coolDown))
        {
            return Time.time < coolDown;
        }
        else
        {
            return false;
        }
    }

    public void SetCooldown(string key, float duration)
    {
        float coolDown = Time.time + duration;
        if (_coolDowns.ContainsKey(key))
        {
            _coolDowns[key] = coolDown;
        }
        else
        {
            _coolDowns.Add(key, coolDown);
        }
    }
}