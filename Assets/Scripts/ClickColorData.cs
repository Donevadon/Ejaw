using System;
using UnityEngine;

[Serializable]
public class ClickColorData
{
    public string objectType;
    public int minClicksCount;
    public int maxClicksCount;
    public Color color;
}