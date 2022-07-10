using UnityEngine;
using TMPro ;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLaber : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] private Color blockedColor = Color.gray;
    
     TextMeshPro label;
     private Vector2Int coordinate = new Vector2Int();
     private WayPoint point;
     
    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        point = GetComponentInParent<WayPoint>();
        DisplayLocation();
        label.enabled = false;
    }


    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayLocation();
            updateTileNmae();
        }

        SetLabelColor();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void SetLabelColor()
    {
        if (point.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }
    
    
    void DisplayLocation()
    {
        coordinate.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinate.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinate.x + "," + coordinate.y ;
    }

    void updateTileNmae()
    {
        transform.parent.name = coordinate.ToString();
    }
}
