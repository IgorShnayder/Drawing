using UnityEngine;

public class PaintingController : MonoBehaviour
{
    [SerializeField] private float _deep;
    [SerializeField] private Camera _camera;
    [SerializeField] private BoxCollider _boardCollider;
    
    private LineRenderer _lineRenderer;
    
    public void DeleteLines()
    {
        var createdObjects = GameObject.FindGameObjectsWithTag(GlobalConstants.LINE_TAG);
        
        foreach (var createdObject in createdObjects)
        {
            Destroy(createdObject);
        }
    }

    public void ChangeColor(Color color)
    {
        var lineMaterial = _lineRenderer.material;
        lineMaterial.color = color;
        _lineRenderer.material = lineMaterial;
    }
    
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && _lineRenderer.positionCount > 0)
        {
            SafeLine();
        }
        
        if (Input.GetMouseButton(0))
        {
            Drawing();
        }
    }
    
    private void SafeLine()
    {
        var mesh = new Mesh();
        _lineRenderer.BakeMesh(mesh);
        var meshObject = new GameObject(GlobalConstants.LINE_TAG) { tag = GlobalConstants.LINE_TAG };
        var meshFilter = meshObject.AddComponent<MeshFilter>();
        meshObject.AddComponent<MeshRenderer>().material.color = _lineRenderer.material.color;
        meshFilter.mesh = mesh;
        
        _lineRenderer.positionCount = 0;
    }
    
    private void Drawing()
    {
        var colliderSize = _boardCollider.size;
        
        var offsetX = (Screen.width - colliderSize.x) * 0.5f;
        var offsetY = (Screen.height - colliderSize.y) * 0.5f;
        
        var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _deep);
        
        mousePosition.x = Mathf.Clamp(mousePosition.x, offsetX, Screen.width - offsetX);
        mousePosition.y = Mathf.Clamp(mousePosition.y, offsetY, Screen.height - offsetY);
        
        Cursor.lockState = CursorLockMode.Confined;
        
        var position = _camera.ScreenToWorldPoint(mousePosition);
        var positionWithDeep = new Vector3(position.x, position.y, _deep);
        gameObject.transform.position = positionWithDeep;
        
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, position);
    }
}
