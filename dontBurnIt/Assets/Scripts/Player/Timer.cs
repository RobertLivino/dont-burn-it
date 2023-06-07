using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float segundosPorMinuto = 60f;
    public float minutosPorHora = 60f;
    public float horasPorDia = 24f;
    public float duracaoDiaEmMinutos = 5f;

    private float tempoTotalEmSegundos = 0f;

    private void Update()
    {
        tempoTotalEmSegundos += Time.deltaTime;

        float segundosPorDia = duracaoDiaEmMinutos * minutosPorHora * segundosPorMinuto;

        float segundos = tempoTotalEmSegundos % segundosPorMinuto;
        float minutos = (tempoTotalEmSegundos / segundosPorMinuto) % minutosPorHora;
        float horas = (tempoTotalEmSegundos / (segundosPorMinuto * minutosPorHora)) % horasPorDia;

        float proporcaoDia = tempoTotalEmSegundos / segundosPorDia;

        Debug.LogFormat("{0:00}:{1:00} - {2:0%}", horas, minutos, proporcaoDia);

        if (tempoTotalEmSegundos >= segundosPorDia)
        {
            // O dia terminou, você pode executar alguma lógica aqui
            tempoTotalEmSegundos = 0f;
        }
    }
}
