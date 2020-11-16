using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class RandomNameWithJson : RandomName
{
    private string jsonName = "JSON.json";

    private void SerializeJson()
    {
        if (!Directory.Exists($"{Application.dataPath}/Resources/Prefabs")) return;
        var fileName = new Names(Directory.GetFiles($"{Application.dataPath}/Resources/Prefabs")
            .Select(Path.GetFileName)
            .Where((fn => fn.EndsWith(".meta") == false) )
            .ToArray());
        for(var i = 0;i<fileName.names.Length;i++)
        {
            if(fileName.names[i].EndsWith(".prefab"))
            {
                fileName.names[i] = fileName.names[i].Replace(".prefab","");
            }
        }
        var json = JsonUtility.ToJson(fileName);
        using(var file = new StreamWriter($"{Application.dataPath}/Resources/" + jsonName, false,System.Text.Encoding.Default))
        {
            file.WriteLine(json);
        }

    }

    private string[] DeserializeJson()
    {
        string json;
        using(var reader = new StreamReader($"{Application.dataPath}/Resources/{jsonName}"))
        {
            json = reader.ReadToEnd();
        }
        var names = JsonUtility.FromJson<Names>(json);
        return names.names;
    }
    private void CreateJson()
    {
        var jsonFile = new FileInfo($"{Application.dataPath}/Resources/{jsonName}");
        if(!jsonFile.Exists)
        {
            SerializeJson();
        }
    }

    protected override string[] GetLoadData()
    {
        CreateJson();
        return DeserializeJson();
    }

    [Serializable]
    private class Names
    {
        public string[] names;
        public Names(string[] names)
        {
            this.names = names;
        }
    }
}

