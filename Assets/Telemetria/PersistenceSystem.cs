using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/*

 //Gestion de nivel :
    InicioSesion,
    InicioNivel,
    FinSesion,
    FinNivel,
    Reinicio, array 
    Pausa,    array 
    //Recogida :
    Coleccionable,
    FotoRecogida,
    FlashRecogida,
    //Uso de :
    BotonCamara,
    FotoUso,
    FlashUso,
    FotoGuardia

public struct TelemetryEvent
{
    public TipoEvento type;
    public DateTime time;
    public int nivel;
    public void setNull() { time = -1.0f; }
}
*/

/*
Estructura:
"Inicio timestamp": "19/06/2015 17:35:50",
"Fin timestamp": 
[
    "19/06/2015 17:35:50",
    "19/06/2015 17:35:50",
    "19/06/2015 17:35:50" 
],
"Reinicio timestamp": 
[
    "19/06/2015 17:35:50",
    "19/06/2015 17:35:50"
],
"Pausa timestamp": 
[
    "19/06/2015 17:35:50"
],
"Salida timestamp": "19/06/2015 17:35:50",
"Coleccionables recogidos": 4,
...

NIVEL 1


"Coleccionable":  " lvl 1, 19/06/2015 17:35:50",
*/

public class PersistenceSystem 
{
    #region FileManager (Opening and closing I/O)

    static string FILEPATH = @".\Telemetria\session_id.txt";

    StreamReader sr = null;
    StreamWriter sw = null;

    public bool OpenReadFile(ref string file_path) //Opens output file (writting) if it isn't already openned
    {
        if (!File.Exists(file_path))
        {
            sr = File.OpenText(file_path);
            return true;
        }
        return false;
    }

    public bool OpenWriteFile (ref string file_path) //Opens output file (writting) if it isn't already openned
    {
        if (!File.Exists(file_path))
        {
            sw = File.CreateText(file_path);
            return true;
        }
        return false;
    }
    #endregion

    #region Data (Last known register)
    string sInicioSesion = "";
    string sInicioNivel = "";
    string sFinSesion = "";
    string sFinNivel = "";
    string sReinicio = "";
    string sPausa = "";
    string sColeccionable = "";
    string sFotoRecogida = "";
    string sFlashRecogida = "";
    string sBotonCamara = "";
    string sFotoUso = "";
    string sFlashUso = "";
    string sFotoGuardia = "";

    //Aux
    string arrayCloser = "\n],\n";
    #endregion

    #region Encoder
    public bool toJson(TelemetryEvent e)
    {
        string result = "";
        switch (e.type)
        {
            case TipoEvento.InicioSesion:
                result = "\"Inicio sesion timestamp\": " + '\"' + e.time.ToString() + "\",\n";
                sInicioSesion = result;
                break;
            case TipoEvento.InicioNivel:
                result = "\"Inicio nivel timestamp\": " + '\"' + e.time.ToString() + "\",\n";
                sInicioNivel = result;
                break;
            case TipoEvento.FinSesion:
                if (first)
                    result = "\"Fin timestamp\": \n[";
                break;
            case TipoEvento.FinNivel:
                if (first)
                    result = "\"Fin timestamp\": \n[";
                break;
            case TipoEvento.Reinicio:
                break;
            case TipoEvento.Pausa:
                break;
            case TipoEvento.Coleccionable:
                break;
            case TipoEvento.FotoRecogida:
                break;
            case TipoEvento.FlashRecogida:
                break;
            case TipoEvento.BotonCamara:
                break;
            case TipoEvento.FotoUso:
                break;
            case TipoEvento.FlashUso:
                break;
            case TipoEvento.FotoGuardia:
                break;
            case TipoEvento.Null:
                break;
            default:
                break;
        }

        return true;
    }
    #endregion
}
