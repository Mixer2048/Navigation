using UnityEngine;

public class Collectable : MonoBehaviour
{
    public void Remove() => Destroy(this.gameObject);
}
