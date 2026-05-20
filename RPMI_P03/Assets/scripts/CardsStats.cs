using UnityEngine;

public class CardsStats : MonoBehaviour
{

    [SerializeField, Tooltip("Ataque de la carta"), Range(1, 9)] private int attack;

    public int GetAttack()
    {
        return attack;
    }

   
}
