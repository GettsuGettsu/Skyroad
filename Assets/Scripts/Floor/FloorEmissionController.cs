using UnityEngine;

public class FloorEmissionController : MonoBehaviour
{
    public Material floorMaterial;
    private float colorValue = 0f;
    
    void Update()
    {
        colorValue = ColorHelper.GetColorValue(colorValue);
        floorMaterial.SetColor("_EmissionColor", new Color(colorValue, colorValue, colorValue));
    }

}
