using System.Collections;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Tmo;
    public float Counter;

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
