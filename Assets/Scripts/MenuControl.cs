using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class MenuControl : MonoBehaviour
{
    public string _IDPaciente;
    public Text InputName;

    public void InicioB()
    {
        _IDPaciente = InputName.text;
        Debug.Log("Paciente: " + _IDPaciente);
        MovimientosControl._patientID = _IDPaciente;
        SceneManager.LoadScene(1);
    }

    public void EnglishB()
    {
        _IDPaciente = InputName.text;
        Debug.Log("Paciente: " + _IDPaciente);
        MovimientosControl._patientID = _IDPaciente;
        SceneManager.LoadScene(2);
    }

    public void SalirB()
    {
        Application.Quit();
    }

}
