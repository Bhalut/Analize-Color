using UnityEngine;

public class Generator : MonoBehaviour 
{
    int nRows; //Declaramos una variable de tipo entero que nos manejará el número aleatoreo de filas que se crearan.
    int nColumns; //Declaramos una variable de tipo entero que nos manejará el número aleatoreo de columnas que se crearan.
    int colorRandom; //Declaramos una variable de tipo entero que nos manejará un rango de números aleatoreo que, depende del número, se asignará un color u otro.
    int i = 1; //Declaramos una variable de tipo entero que será el contador de filas del ciclo que crea los objetos.
    int j; //Declaramos una variable de tipo entero que será el contador de columnas del ciclo que crea los objetos.
    int k = 1; //Declaramos una variable de tipo entero que será utilizada para manejar un poco el orden en los nombres de todas los objetos que se creen.

    public bool activator; //Declaramos una variable de tipo booleana pública que será el checkbox con el que activaremos la creación de los objetos. 
    bool activatorT = true; //Declaramos una variable de tipo booleana que nos controlará la variable anterior, para que no entre en un bucle infinito.

    GameObject beforeObj; //Declaramos una variable de tipo GameObject en donde se almacenará el objeto anterior con respecto a la que se acaba de crear.

    void Start() //Utilizamos la función "Start" para inicializar la variables requeridas
    {
        nRows = Random.Range(2, 18); //Inicializamos la variable anteriormente creada con un número aleatorio entre 2 y 18.
        nColumns = Random.Range(2, 20); //Inicializamos la variable anteriormente creada con un número aleatorio entre 2 y 20.
        beforeObj = null; //Inicializamos la variable anteriormente creada como nula, ya que esta variable no contendrá ningun objeto en la primera repetición del bucle que crea los objetos. 
    }

    void Update() //Utilizamos la funcion "Update" para que verifique el checkbox asi:
    {
        if (activatorT == true) //La variable anteriormente fue declarada como "verdadera", y si esta variable es verdadera, al cumplirse la condición pasará al bloque de código que hay dentro de este "if".
        {
            if (activator == true) //Despues de verificarse que la condición anterior es verdadera pasamos a una nueva. La variable anteriormente fue declarada como "falso", y en este condicional estamos preguntando si esta variable es verdadera, por lo tanto en un principio esto no se cumplirá, así que no pasará al siguiente bloque de código, para que este sea verdadero solo hay que activarlo desde el Inspector de Unity. 
            {
                activatorT = false; //Cuando lo anterior se cumpla llegará a esta parte en donde, a la variable pasará a ser falso.
                activator = false; //Al llegar aquí la variable también pasará a ser falsa, esto para que no entre en un bucle infinito.
                ObjectHit(); //llamar al metodo.
            }
        }
    }

    public void ObjectHit() //Esta es la función que se encarga de crear los objetos y que fue llamada anteriormente.
    {
        while (i < nRows) //Dentro de la función creamos un bucle que se repetirá las veces que se cumpla la condición que esta entre paréntesis.
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere); //Después de verificar que lo anterior sea verdadero, creara un GameObject, en este caso un objeto de tipo esfera.
            sphere.transform.position = new Vector3(i, j, 0); //Despues de instanciar la esfera, esta línea lo que hace es ubicarme dicha esfera dentro de la escena de Unity por medio de coordenadas, en donde X valdrá "i" es decir 1 en este primer caso, Y valdrá "j" (anteriormente creada) es decir 0 en este primer caso y Z siempre valdrá 0 ya que no trabajaremos con profundidad.
            colorRandom = Random.Range(1, 6); //Inicializamos la variable anteriormente creada "colorRandom" con un número aleatorio entre 1 y 6, y esta variable es la que nos dará un número que, dependiendo de este, se asignara un color u otro a la esfera creada.
            sphere.name = "sphere " + k; //En esta linea lo que se hace es simplemente darle un nombre a esa esfera que se creó, es decir, por defecto la esfera que se crea pasa a ser llamada "Sphere", así que esta línea es solo por organizar los nombres para que todas no se llamen igual.

            switch (colorRandom) //Después de que se ejecute lo anteior pasará a esta línea, que también recibe un argumento, se realizará una y u otra de las siguientes lineas, por lo tanto estamos preguntando que según lo que haya dentro del parentesis se ejecute lo siguiente:
            {
                case 1: //Esta es la forma de decir que, en caso que sea el número 1 aquel que fue dado como argumento, es decir, que en caso que la variable "colorRandom" haya valido 1, se realice el paso siguiente.
                    sphere.gameObject.GetComponent<Renderer>().material.color = Color.grey; //Así es como se le puede asignar un color al objeto que se acaba de crear.
                    break; //Break se utiliza para, romper o quebrar el bloque de código que sigue, en este caso, en el "switch", es decir, el resto de casos ya no se leerán.
                case 2:
                    sphere.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                    break;
                case 3:
                    sphere.gameObject.GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 4:
                    sphere.gameObject.GetComponent<Renderer>().material.color = Color.green;
                    break;
                case 5:
                    sphere.gameObject.GetComponent<Renderer>().material.color = Color.magenta;
                    break;
                default:
                    sphere.gameObject.GetComponent<Renderer>().material.color = Color.white;
                    break;
            }

            i++; //Esta línea que lo único que hace es sumarle 1 al número que tenga la variable "i", por lo tanto, en este caso la variable vale 1, y al llegar a esta línea, "i++" le sumara 1 a "i", es decir que la variable quedará valiendo ahora mismo 2.
            k++; //Esta línea hace lo mismo que la anterior, solo que se le aplicará a la variable "k".

            Analize analize = sphere.AddComponent<Analize>(); //Aquí estamos haciendo una instancia de una clase que esta en otro script la cual tiene otro código.
            analize.AnalizeColor(beforeObj, sphere); //Utilizamos el metodo que esta clase contiene para hacer el analisis de los colores.
            beforeObj = sphere; //Utilizamos la variable creada al principio y se le asignará la variable "sphere" que contiene la esfera que se acaba de crear.

            if (i == nRows) //Verificamos si "i" llego a ser igual a la variable "nRows", en caso que sea verdadero pasará a lo siguiente.
            {
                i = 1; //"i" pasa a ser 1 de nuevo para que las esferas pasen a ser instanciadas de nuevo en la posicion 1 en la coordenada de X.
                j++; //"j" que valía 0, pasa a ser 1 con "j++", es decir, X vuelve a empezar pero Y pasa a ser una unidad mayor, por lo tanto, este proceso se repetira una y otra vez hasta que la condicion que hay en el ciclo "while" sea falso, se creará otra fila de esferas encima de la anterior.
            }

            if (j == nColumns) //Verificamos que cuando "j" sea igual al número random, quiere decir que ya se crearon todas las filas y columnas asignadas por las variables Random.
            {
                break; //Se detiene con el objetivo de que no sea infinito.
            }
        }
    }
}
