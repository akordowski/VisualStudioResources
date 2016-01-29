using System;
using System.Runtime.Serialization;

namespace $rootnamespace$
{
	/// <summary>
	/// Stellt Fehler dar, die beim Ausführen einer Anwendung auftreten.
	/// </summary>
	public class $safeitemname$ : Exception
	{
		#region Constructor
		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="$safeitemname$"/>-Klasse.
		/// </summary>
		public $safeitemname$()
			: base()
		{
		}

		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="$safeitemname$"/>-Klasse mit einer angegebenen Fehlermeldung.
		/// </summary>
		/// <param name="message">Die Meldung, in der der Fehler beschrieben wird.</param>
		public $safeitemname$(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="$safeitemname$"/>-Klasse mit einer angegebenen Fehlermeldung und einem Verweis auf die innere Ausnahme, die diese Ausnahme ausgelöst hat.
		/// </summary>
		/// <param name="message">Die Fehlermeldung, in der die Ursache der Ausnahme erklärt wird.</param>
		/// <param name="innerException">Die Ausnahme, die die aktuelle Ausnahme verursacht hat, oder ein Nullverweis, wenn keine innere Ausnahme angegeben ist.</param>
		public $safeitemname$(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="$safeitemname$"/>-Klasse mit serialisierten Daten.
		/// </summary>
		/// <param name="info">Die <see cref="SerializationInfo"/>, die die serialisierten Objektdaten für die ausgelöste Ausnahme enthält.</param>
		/// <param name="context">Der <see cref="StreamingContext"/>, der die Kontextinformationen über die Quelle oder das Ziel enthält.</param>
		/// <exception cref="ArgumentNullException">Der <em>info</em> Parameter ist <strong>null</strong>.</exception>
		/// <exception cref="SerializationException">Der Klassenname ist <strong>null</strong> oder <see cref="HResult"/> ist null (0).</exception>
		protected $safeitemname$(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
		#endregion
	}
}