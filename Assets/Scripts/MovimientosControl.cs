using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using System.IO;
using System.Diagnostics;


public class MovimientosControl : MonoBehaviour
{
    public static string fase;
    public static string _patientID;
    [HideInInspector] public string faseDos;
    [HideInInspector] public string faseTres;
    public int image1;
    public int image2;
    public int image3;
    public GameObject[] flechas;
    public GameObject[] numeros;
    public int contador;
    public static int _contador;
    public static int rep;
    public TextAsset orden;
    [HideInInspector] public string[] part;
    [HideInInspector] public int i;
    [HideInInspector] public int iAR;
    
    public SteamVR_Action_Boolean trigger;

    [HideInInspector] public Animator movimientos;
    public AudioManager am;

    public bool unBlockTrigger;
    public static bool _unBlockTrigger;

    // Start is called before the first frame update
    void Start()
    {
        movimientos = GetComponent<Animator>();

        contador = 0;

        unBlockTrigger = false;

        string[] pte = orden.text.Split(new char[] { '\n' });

        for (int i = 1; i < pte.Length - 1; i++)
         {
            part = pte[i].Split(new char[] { ',' });
            {
                if (part[0] == _patientID)
                {
                    fase = part[1];
                    faseDos = part[2];
                    faseTres = part[3];
                }

            }
         }

            UnityEngine.Debug.Log("Ejercicio1= " + fase + ", Ejercicio2= " + faseDos + ", Ejercicio3= " + faseTres);

            StartCoroutine(PlayIntro());
 
    }

    // Update is called once per frame
    void Update()
    {
        _contador = contador;
        _unBlockTrigger = unBlockTrigger;

        if (unBlockTrigger == true)
        {
            if (trigger.stateDown)
            {
                contador++;

                if (contador == 1)
                {
                    unBlockTrigger = false;
                    rep = 0;
                    StartCoroutine(PlayAnimations());
                    StartCoroutine(Fase());
                    fase = faseDos;
                }

                else if (contador == 2 || contador == 6 || contador == 10)
                {
                    unBlockTrigger = false;
                    rep = 1;
                    StartCoroutine(Rep());
                }
                else if (contador == 3 || contador == 7 || contador == 11)
                {
                    unBlockTrigger = false;
                    rep = 2;
                    StartCoroutine(Rep());

                }
                else if (contador == 4 || contador == 8 || contador == 12)
                {
                    unBlockTrigger = false;
                    rep = 3;
                    StartCoroutine(Rep());

                }
                else if (contador == 5)
                {
                    unBlockTrigger = false;
                    rep = 0;
                    StartCoroutine(PlayAnimations());
                    StartCoroutine(Fase());
                    fase = faseTres;
                }
                else if (contador == 9)
                {
                    unBlockTrigger = false;
                    rep = 0;
                    StartCoroutine(PlayAnimations());
                    StartCoroutine(Fase());
                }
                else if (contador == 13)
                {

                    am.PlayAudio(8);

                }

            }
        }
        
                
    }

    private IEnumerator PlayAnimations()
    {
        unBlockTrigger = false;
        switch (fase)
        {
            case "Flex":
                yield return new WaitForSeconds(2.5f);
                movimientos.SetBool("A_Ab", true);
                movimientos.SetBool("D_I", false);
                movimientos.SetBool("LD_LI", false);
                break;
            case "Rot":
                yield return new WaitForSeconds(2.5f);
                movimientos.SetBool("D_I", true);
                movimientos.SetBool("A_Ab", false);
                movimientos.SetBool("LD_LI", false);
                break;
            case "Lat":
                yield return new WaitForSeconds(2.5f);
                movimientos.SetBool("LD_LI", true);
                movimientos.SetBool("A_Ab", false);
                movimientos.SetBool("D_I", false);
                break;
        }
        
    }
    private IEnumerator Fase()
    {

        switch (fase)
        {
            case "Flex":
                iAR = 4;
                image1 = 1;
                image2 = 0;
                break;
            case "Rot":
                iAR = 5;
                image1 = 3;
                image2 = 2;
                break;
            case "Lat":
                iAR = 6;
                image1 = 5;
                image2 = 4;
                break;
        }
        unBlockTrigger = false;
        yield return new WaitForSeconds(0.5f);
        am.PlayAudio(iAR);
        yield return new WaitForSeconds(2.0f);
        flechas[image1].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        flechas[image1].SetActive(false);
        flechas[image2].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        flechas[image2].SetActive(false);
        yield return new WaitForSeconds(AudioManager._aLength - 3.5f);
        StopCor();
        StopThisCor();
        //yield return new WaitForSeconds(0.5f);
        am.PlayAudio(1);
        yield return new WaitForSeconds(AudioManager._aLength - 2.0f);
        unBlockTrigger = true;
    }
    private IEnumerator Rep()
    {
        
        switch (rep)
        {
            case 1:
                image3 = 0;
                i = 2;
                break;
            case 2:
                image3 = 1;
                i = 3;
                break;
            case 3:
                image3 = 2;
                i = 7;
                break;
        }

        unBlockTrigger = false;
        yield return new WaitForSeconds(1.0f);
        numeros[image3].SetActive(true);
        yield return new WaitForSeconds(5.0f);
        numeros[image3].SetActive(false);
        yield return new WaitForSeconds(2.0f);
        am.PlayAudio(i);
        yield return new WaitForSeconds(AudioManager._aLength);
        unBlockTrigger = true;
        StopOtherCor();
    }
    
    private IEnumerator PlayIntro()
    {
        yield return new WaitForSeconds(5.0f);
        am.PlayAudio(0);
        yield return new WaitForSeconds(AudioManager._aLength);
        unBlockTrigger = true;
        StopAudioCor();
    }
    private void StopAudioCor()
    {
        StopCoroutine(PlayAnimations());
    }
    private void StopCor()
    {
        StopCoroutine(PlayAnimations());
    }
    private void StopThisCor()
    {
        unBlockTrigger = false;
        StopCoroutine(Fase());
        flechas[image1].SetActive(false);
        flechas[image2].SetActive(false);
        movimientos.SetBool("A_Ab", false);
        movimientos.SetBool("D_I", false);
        movimientos.SetBool("LD_LI", false);
    }
    private void StopOtherCor()
    {
        StopCoroutine(Rep());
    }
}  