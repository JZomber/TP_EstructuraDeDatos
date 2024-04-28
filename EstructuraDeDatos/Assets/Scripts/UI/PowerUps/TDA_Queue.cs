using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UI.PowerUps
{
    public class TDA_Queue : MonoBehaviour
    {
        public Image[] imagePowerUps; //Array de imagenes
        private GameObject currentImg; //Imagen actual (default = null)
        
        private QueueTdaCola<GameObject> powerUpsQueue = new QueueTdaCola<GameObject>(); //Cola de powerUps
        private int maxSize = 3; //Tamaño del array
        
        public Transform powerUpParent; //Punto donde aparecen en UI
        public GameObject player; //Referencia al jugador
        
        // Start is called before the first frame update
        void Start()
        {
            powerUpsQueue.InitQueue(maxSize); //Inicializa la lista
        }

        public void AddPowerUp(GameObject obj)
        {
            powerUpsQueue.Acolar(obj); //Agrego la referencia al objeto a la lista
            UpdatePowerDisplay();
            obj.SetActive(false);
        }

        public void RemovePowerUp() //Quito el primer objeto que entró a la lista
        {
            powerUpsQueue.DesAcolar();
            Destroy(currentImg);
            UpdatePowerDisplay();
        }

        private void InstantiatePowerUpUI(GameObject img)
        {
            currentImg = Instantiate(img, powerUpParent); //Instancio la imagen actual del objeto en la lista
        }

        private void UpdatePowerDisplay()
        {
            GameObject firstPowerUp = powerUpsQueue.First(); //Obtengo al referencia al primer objeto en entrar
            
            for (int i = 0; i < imagePowerUps.Length; i++)
            {
                if (firstPowerUp.name == imagePowerUps[i].name) //Comparo el nombre del objeto con el de las imágenes
                {
                    Destroy(currentImg);
                    InstantiatePowerUpUI(imagePowerUps[i].GameObject()); //Muestro la referencia de la imagen
                    break;
                }
            }
        }
    }
}
