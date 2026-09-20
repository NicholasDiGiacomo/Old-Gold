using System.Collections;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Tmo;
   [SerializeField] public float Counter = 40;

    private void Start()
    {
        Counter = 40;
    }

    private void Update()
    {
        Tmo.text = Mathf.CeilToInt(Counter).ToString();

        if (Counter > 0)
        {
            Counter -= Time.deltaTime;
        }
    }

}
