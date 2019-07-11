using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    void Shoot();
    void Reload();
    int GetAmmo();
    void AddAmmo(int amount);
    string GetGunName();
    string ToString();
}
