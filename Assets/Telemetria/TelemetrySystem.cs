using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal enum SerializeType { JSON, PLAIN };

public class TelemetrySystem : MonoBehaviour{


    #region SINGLETON
    private static TelemetrySystem _instance;

    public static TelemetrySystem Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion
    private List<Evento> eventQueue; // Lista de eventos recogidos a la espera de tratamiento
    private int saveFrequency; // La frecuencia en ms con la que el sistema serializa y graba
    SerializeType encoding; 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if tiempo > x
  //          while lista no vacía
  //                  SERIALIZAR(lista pop evento.toJSON)
	}

    // SERIALIZAR
    //lista tocha de todos los datos del json nuevos
    //    Sobreescribimos o creamos el archivo
}
