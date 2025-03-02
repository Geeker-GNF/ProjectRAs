﻿using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class CapturarText : MonoBehaviour {

	public InputField CampoTexto;
	public string ruta;
	public GameObject groupInputField;
	public InputField tmp;
	public int contadorFase;
	public GameObject FaseCompletada;
	public GameObject canvas;

	void Start(){
		//ruta = Application.dataPath;
		ruta = Application.persistentDataPath;
		ruta += "/Resources/Comentarios/";
		Directory.CreateDirectory (ruta);
		ruta += "Comentarios.txt";
		if (File.Exists(ruta)) {
			if(contadorFase == 1 || contadorFase == 4)
				tmp.text = "Comentarios Fase" + contadorFase +"\n"+ File.ReadAllText (ruta);

			if(contadorFase > 1)
				tmp.text = File.ReadAllText (ruta) +"\n" + "Comentarios Fase" + contadorFase + "\n";

		} else {
			File.Create (ruta);
		}
	}
	public void ActivarTexto (){
	 if (contadorFase == 1 || contadorFase == 4) {
			groupInputField.SetActive (true);
			TouchScreenKeyboard.Open ("", TouchScreenKeyboardType.Default, false, true, true, true);
			System.Diagnostics.Process.Start ("osk.exe");
			canvas.GetComponent<Teclado> ().mostrar = 1;
		} else {
			FaseCompletada.SetActive (true);
		}
	}
	public void guardar(){
		if (contadorFase == 1 || contadorFase == 4) {
			tmp.text += CampoTexto.text;
			File.WriteAllText (ruta, tmp.text, System.Text.Encoding.UTF8);
		}
		FaseCompletada.SetActive (true);
	}
} 