using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnMouseDrag()
    {
        //No podemos hacer que vaya a la posición de la cámara porque lee también el eje z, por lo que hay que crear una variable Vector 3 y hacer lo siguiente
        Vector3 newPosition = transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        transform.position = newPosition;

    }

    private void OnMouseDown()
    {
        //cambia la jerarquía de la carta arriba cuando le pulsas
        GetComponent<SpriteRenderer>().sortingLayerName = "Selected Cards";

    }

    private void OnMouseUp()
    {
        //cambia la jerarquía de la carta abajo cuando le pulsas
        GetComponent<SpriteRenderer>().sortingLayerName = "Default";
    }
}
