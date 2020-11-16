using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GeometryObjectModel : MonoBehaviour,IGeometryModel
{
    private int _clickCount;
    private Color _color;
    [SerializeField]private string type;
    public string Type => type;

    private event EventHandler<Color> ColorChanged;

    private void SetColor(ref Color color)
    {
        this._color = color;
    }

    public int AddClick()
    {
        return ++_clickCount;
    }

    private void Start()
    {
        ColorChanged += ((x,y) => GetComponent<MeshRenderer>().material.color = y);
        Observable.Timer(System.TimeSpan.FromSeconds(Resources.Load<GameData>("GameData").observableTime))
        .Repeat()
        .Subscribe(_ => {ColorChanged?.Invoke(this,new Color
            (
                UnityEngine.Random.Range(0,1f),
                UnityEngine.Random.Range(0,1f),
                UnityEngine.Random.Range(0,1f)
            )
        );
        })
        .AddTo(this);
    }

    public void ChangeColor(Color color)
    {
        this._color = color;
        ColorChanged?.Invoke(this,this._color);
    }
}
