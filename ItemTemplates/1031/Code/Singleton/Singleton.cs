using System;

namespace $rootnamespace$
{
    /// <summary>
    /// Stellt eine Singleton-Klasse bereit.
    /// </summary>
    public sealed class $safeitemname$
    {
        #region Private Static Properties
        /// <summary>
        /// Enthält die Referenz der Instanz der $safeitemname$-Klasse.
        /// </summary>
        private static volatile $safeitemname$ _instance;
        
        /// <summary>
        /// Enthält ein Objekt, mit dem die Initialisierung der $safeitemname$-Klasse synchronisiert
        /// wird.
        /// </summary>
        private static object _syncRoot = new Object();
        #endregion

        #region Constructor
        /// <summary>
        /// Initialisiert eine neue Instanz der $safeitemname$-Klasse.
        /// </summary>
        private $safeitemname$()
        {
        }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Gibt eine Instanz der <see cref="$safeitemname$"/>-Klasse zurück.
        /// </summary>
        /// <returns>Eine Instanz der <see cref="$safeitemname$"/>-Klasse.</returns>
        public static $safeitemname$ GetInstance()
        {
            if (_instance == null)
            {
                lock (_syncRoot)
                {
                    if (_instance == null)
                        _instance = new $safeitemname$();
                }
            }

            return _instance;
        } 
        #endregion
    }
}