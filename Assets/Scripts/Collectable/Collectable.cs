using UnityEngine;

public class Collectable : MonoBehaviour
{
    public void TakeItem() => Destroy(this.gameObject);
}