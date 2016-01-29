using System;
using System.Runtime.Serialization;

namespace $rootnamespace$
{
	/// <summary>
	/// Represents errors that occur during application execution.
	/// </summary>
	public class $safeitemname$ : Exception
	{
		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="$safeitemname$"/> class.
		/// </summary>
		public $safeitemname$()
			: base()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="$safeitemname$"/> class with a specified error message.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public $safeitemname$(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="$safeitemname$"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
		public $safeitemname$(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="$safeitemname$"/> class with serialized data.
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
		/// <exception cref="ArgumentNullException">The <em>info</em> parameter is <strong>null</strong>.</exception>
		/// <exception cref="SerializationException">The class name is <strong>null</strong> or <see cref="HResult"/> is zero (0).</exception>
		protected $safeitemname$(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
		#endregion
	}
}