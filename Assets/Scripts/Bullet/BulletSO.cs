using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum bulletType
{
  Slow,
  Heal,
  ManyBullet

}
[CreateAssetMenu(fileName = "Bullets", menuName = "Bullets/BulletData")]
public class BulletSO : ScriptableObject
{
    public bulletType bulletType;
    
    public float debuffAmount;
}