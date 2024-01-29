using System;
using UnityEngine;

public class ChalkButton : MonoBehaviour
{
    public event Action<Color> ButtonPushed; 

    [SerializeField] private Color _color;

    public void PushButton()
    {
        ButtonPushed?.Invoke(_color);
    }
}
