using System.Collections;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Tmo;
    [SerializeField] public float Counter = 80;

    private void Start()
    {
        Counter = 80;
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
