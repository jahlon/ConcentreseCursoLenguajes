using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConcentreseComun
{
    public abstract class HiloBase
    {
        private readonly Thread hilo;

        protected HiloBase()
        {
            hilo = new Thread(new ThreadStart(EjecutarHilo));
        }

        public void Start() => hilo.Start();
        public void Join() => hilo.Join();
        public bool IsAlive => hilo.IsAlive;
        public bool IsBackground
        {
            get => hilo.IsBackground;

            set => hilo.IsBackground = value;
        }

        protected abstract void EjecutarHilo();


    }
}
