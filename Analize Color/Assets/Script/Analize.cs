using UnityEngine;

public class Analize : MonoBehaviour 
{
    public void AnalizeColor(GameObject beforeObj, GameObject currentObj) //Metodo para analizar y cambiar los colore de los objetos, el cual resive DOS argumentos de tipo GameObject los cuales son los objetos que se analizaran para la revision de su material.
    {
        if (beforeObj != null) //si la variable "beforeObj" no esta vacia, entonces:
        {
            Color before = beforeObj.GetComponent<Renderer>().material.color; //Declaramos una variable de tipo Color, para guardar el material del objeto.
            Color current = currentObj.GetComponent<Renderer>().material.color; //Declaramos una variable de tipo Color, para guardar el material del objeto.

            if (before == current) //si el color de "before" es igual al color de "current", hara lo siguiente:
            {
                beforeObj.GetComponent<Renderer>().material.color = Color.black; //tomará color negro.
                currentObj.GetComponent<Renderer>().material.color = Color.black; //tomará color negro.
            }
        }
    }
}
