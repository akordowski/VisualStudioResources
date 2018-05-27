using System;
using System.Collections.Generic;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;

namespace $rootnamespace$
{
    /// <summary>
    /// Provides a abstract <see cref="$safeitemname$"/> class.
    /// </summary>
    public abstract class $safeitemrootname$
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="$safeitemname$"/> class.
        /// </summary>
        protected $safeitemname$()
        {
        }
        #endregion
    }
}