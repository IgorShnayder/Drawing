using UnityEngine;

public class ColorIndicator : MonoBehaviour
{ 
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _viewDeep;

    private Camera _camera;
    private bool _isIndicatorActive;
    
    public void ChangeIndicatorColor(Color color)
    {
        if (!_isIndicatorActive)
        {
            ActivateIndicator();
        }
        
        color.a = 1;
        _spriteRenderer.color = color;
    }
    
    private void Awake()
    {
        _camera = Camera.main;
        MoveIndicator();
    }
    
    private void Update()
    {
        MoveIndicator();
    }

    private void ActivateIndicator()
    {
        gameObject.SetActive(true);
        _isIndicatorActive = true;
    }
    
    private void MoveIndicator()
    {
        var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _viewDeep);
        var position = _camera.ScreenToWorldPoint(mousePosition);
        transform.position = position;
    }
}
