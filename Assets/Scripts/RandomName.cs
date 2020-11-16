using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public abstract class RandomName : IName
{
    public int Count => GetLoadData().Length;

    public string GetName(int index)
    {
        return GetLoadData()[index];
    }

    protected abstract string[] GetLoadData();
}
