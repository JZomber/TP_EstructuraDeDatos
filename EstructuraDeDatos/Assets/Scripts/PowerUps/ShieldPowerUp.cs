using UnityEngine;

namespace PowerUps
{ 
    public class ShieldPowerUp : MonoBehaviour
    {
        public int damageResist = 5;
        
        private void Update()
        {
            if (damageResist <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
