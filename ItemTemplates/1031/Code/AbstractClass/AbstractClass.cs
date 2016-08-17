using System;
using System.Collections.Generic;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;

namespace $rootnamespace$
{
	/// <summary>
	/// Stellt eine abstrakte <see cref="$safeitemname$"/>-Klasse bereit.
	/// </summary>
	public abstract class $safeitemrootname$
	{
		#region Constructor
		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="$safeitemname$"/>-Klasse.
		/// </summary>
		protected $safeitemname$()
		{
		}
		#endregion
	}
}