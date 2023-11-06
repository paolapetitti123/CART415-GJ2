using UnityEngine;

public class RecycleBin : MonoBehaviour
{
    public void DeleteItem(GameObject item)
    {
        Destroy(item);
    }
}