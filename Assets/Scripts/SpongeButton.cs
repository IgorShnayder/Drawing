using System;
using UnityEngine;

public class SpongeButton : MonoBehaviour
{
    public event Action ButtonPushed; 
    
    public void PushButton()
    {
        ButtonPushed?.Invoke();
    }
}
