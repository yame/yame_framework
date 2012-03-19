using System;

namespace Yame.Core
{
    public class Initializer
    {
        private static readonly object SyncLock = new object();

        private static Initializer instance;

        private bool dbIsLoaded;

        protected Initializer()
        {
        }

        public static Initializer Instance()
        {
            if( instance == null )
            {
                lock( SyncLock )
                {
                    if( instance == null )
                    {
                        instance = new Initializer();
                    }
                }
            }

            return instance;
        }


        public void InitializeOnce(Action initMethod)
        {
            lock( SyncLock )
            {
                if( !this.dbIsLoaded )
                {
                    initMethod();
                    this.dbIsLoaded = true;
                }
            }
        }
    }
}
