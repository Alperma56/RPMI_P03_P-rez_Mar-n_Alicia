using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    public AudioSource takeCardAS;
    public AudioSource dropCardAS;
    public GameObject combatSystem;

    private void OnMouseDrag()
    {
        //No podemos hacer que vaya a la posición de la cámara porque lee también el eje z, por lo que hay que crear una variable Vector 3 y hacer lo siguiente
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        transform.position = newPosition;
    }

    private void OnMouseDown()
    {
        //cambia la jerarquía de la carta arriba cuando le pulsas
        GetComponent<SpriteRenderer>().sortingLayerName = "Selected Cards";
        GetComponent<BoxCollider2D>().enabled = true;

        if (!takeCardAS.isPlaying)
        {
            takeCardAS.pitch = Random.Range(0.95f, 1.05f);
            takeCardAS.Play();
        }

    }

    private void OnMouseUp()
    {
        //cambia la jerarquía de la carta abajo cuando le pulsas
        GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        GetComponent<BoxCollider2D>().enabled = false;

        if (!dropCardAS.isPlaying)
        {
            dropCardAS.pitch = Random.Range(0.95f, 1.05f);
            dropCardAS.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!collision.gameObject.GetComponent<EnemyCard>().inCombat)
            {
                GameObject cs = Instantiate(combatSystem, transform.position, Quaternion.identity); // cs de combat system
                cs.GetComponent<CombatSystem>().playerCard = GetComponent<CardsStats>();
                cs.GetComponent<CombatSystem>().enemyCard = collision.gameObject.GetComponent<CardsStats>();
            }
        }
    }
}
