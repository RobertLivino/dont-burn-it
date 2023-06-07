using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horas : MonoBehaviour
{
   
        public float segundosPorMinuto = 60f;
        public float minutosPorHora = 60f;

        private float tempoTotalEmSegundos = 0f;

    private void Update()
    {
        tempoTotalEmSegundos += Time.deltaTime;

        float horas = tempoTotalEmSegundos / (segundosPorMinuto * minutosPorHora);
        float minutos = (tempoTotalEmSegundos / segundosPorMinuto) % minutosPorHora;
        float segundos = tempoTotalEmSegundos % segundosPorMinuto;

        Debug.LogFormat("{0:00}:{1:00}:{2:00}", horas, minutos, segundos);
    }
}
