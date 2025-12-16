using UnityEngine;

public class TimeBlocks : MonoBehaviour
{

    [Header("Time To Live")]
    [SerializeField] private float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

}
