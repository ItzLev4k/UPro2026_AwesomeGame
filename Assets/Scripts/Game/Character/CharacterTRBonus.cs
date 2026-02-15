using UnityEngine;

public class CharacterTRBonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<IBonus>()?.Use();
    }
}
