using System;

namespace PCO.SDK.NET;

/// <summary>
/// Exception used to mediate errors in the PCO.SDK library.
/// </summary>
public class PcoException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PcoException"/> class.
    /// </summary>
	public PcoException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PcoException"/> class, with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
	public PcoException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PcoException"/> class, with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
	public PcoException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PcoException"/> class, with a message translated from supplied error code.
    /// </summary>
    /// <param name="errorCode">Error code retrieved from a library command.</param>
    public PcoException(int errorCode) : base(GetLastError.ToString(errorCode)) { }
}