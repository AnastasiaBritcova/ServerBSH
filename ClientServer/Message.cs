using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;


namespace ClientServer
{
    [Serializable]
    enum TypeMessage
    {
        Ready,
        Shot, 
        ResultShot
    };

    [Serializable]
    enum PointStatus // это наверное должно быть в классе айтема
    {
        //мимо
        //ранен
        //убит
    }


    [Serializable]
    class Message
    {
        public TypeMessage typeMessage { get; set; }
        public Point point { get; set; }
        public PointStatus pointStatus { get; set; }
        // Ship;



    }
}
