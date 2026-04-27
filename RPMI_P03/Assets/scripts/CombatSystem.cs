using UnityEngine;

public class CombatSystem : MonoBehaviour
{

    public CardStats playerCard;
    public CardStats enemyCard;
    public Transform playerPos;
    public Transform enemyPos;

    void Start()
    {
        CardLocate();

        if (playerCard.GetAttack() >= enemyCard.GetAttack())
        {
            StartCoroutine(AttackPlayer());
        }
        else
        {
            StartCoroutine(AttackEnemy());
        }
    }

    private void CardLocate()
    {
        playerCard.transform.parent = playerPos;
        playerCard.transform.localPosition = Vector3.zero; // que se ponga justo en la posición del padre sin variar nada
        playerCard.GetComponent<SpriteRenderer>().flipX = true;
        enemyCard.transform.parent = enemyPos;
        enemyCard.transform.localPosition = Vector3.zero;
    }

    private IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(1);
        Destroy(enemyCard.gameObject);
    }

    private IEnumerator AttackEnemy()
    {
        yield return new WaitForSeconds(1);
        Destroy(playerCard.gameObject);
    }
}
