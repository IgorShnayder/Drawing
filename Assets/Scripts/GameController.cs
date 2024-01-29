using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PaintingController _paintingController;
    [SerializeField] private BoardView _boardView;

    private void Awake()
    {
        foreach (var boardViewChalkButton in _boardView.ChalkButtons)
        {
            boardViewChalkButton.ButtonPushed += _paintingController.ChangeColor;
            boardViewChalkButton.ButtonPushed += _boardView.ColorIndicator.ChangeIndicatorColor;
        }

        _boardView.SpongeButton.ButtonPushed += _paintingController.DeleteLines;
    }

    private void OnDestroy()
    {
        foreach (var boardViewChalkButton in _boardView.ChalkButtons)
        {
            boardViewChalkButton.ButtonPushed -= _paintingController.ChangeColor;
            boardViewChalkButton.ButtonPushed -= _boardView.ColorIndicator.ChangeIndicatorColor;
        }
        
        _boardView.SpongeButton.ButtonPushed -= _paintingController.DeleteLines;
    }
}
