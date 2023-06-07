using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HourCounter : MonoBehaviour
{
    public float hoursInDay = 24f;
    public float currentHour = 0f;

    private void Update()
    {
        // Incrementa a hora atual com base no tempo decorrido desde o último frame
        currentHour += Time.deltaTime * (24f / hoursInDay);

        // Verifica se passou um dia inteiro e reinicia a contagem
        if (currentHour >= 24f)
        {
            currentHour = 0f;
        }

        // Exibe a hora atual no console
        Debug.Log("Hora atual: " + currentHour.ToString("0"));
    }
}