using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithMac
{
    public class PartGame
    {
        private Macron _mac;
       
        
        public PartGame()
        {
            _mac = new Macron(this);

        }

        public void Update()
        {

        }

        public Macron Mac => this._mac;
    }
}
