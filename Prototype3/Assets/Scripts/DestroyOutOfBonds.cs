using UnityEngine;

public class DestroyOutOfBonds : MonoBehaviour
{
    public int minX = -10;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < minX)
        {
            Destroy(gameObject);
        }
    }
}
