using System;

namespace $rootnamespace$
{
    /// <summary>
    /// Provides a Singleton class.
    /// </summary>
    public sealed class $safeitemname$
    {
        #region Private Static Properties
        /// <summary>
        /// Contains the instance reference of the $safeitemname$ class.
        /// </summary>
        private static volatile $safeitemname$ _instance;
        
        /// <summary>
        /// Contains an object, that is used to synchronize the initialisation of the $safeitemname$
        /// class.
        /// </summary>
        private static object _syncRoot = new Object();
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the $safeitemname$ class.
        /// </summary>
        private $safeitemname$()
        {
        }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Gets an instance of the <see cref="$safeitemname$"/> class.
        /// </summary>
        /// <return>An instance of the <see cref="$safeitemname$"/> class.</return>
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