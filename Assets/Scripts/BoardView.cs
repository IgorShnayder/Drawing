using System.Collections.Generic;
using UnityEngine;

public class BoardView : MonoBehaviour
{
    [field: SerializeField] public List<ChalkButton> ChalkButtons { get; private set; }
    [field: SerializeField] public SpongeButton SpongeButton { get; private set; }
    [field: SerializeField] public ColorIndicator ColorIndicator { get; private set; }
}
