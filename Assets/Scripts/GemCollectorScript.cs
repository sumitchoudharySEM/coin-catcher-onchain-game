using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollectorScript : MonoBehaviour
{
    public int gemCount = 0;
    [SerializeField] private TMPro.TextMeshProUGUI gemCountText;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            Destroy(collision.gameObject);
            gemCount++;
            gemCountText.text = gemCount.ToString();
        }
    }
}
