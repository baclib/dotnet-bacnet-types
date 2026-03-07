// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the choice AuthRequest-ACK as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuthRequestAck
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// The access token returned in response to the authentication request.
        /// </summary>
        TokenResponse
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private AuthRequestAck(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// The access token returned in response to the authentication request.
    /// </summary>
    public AccessToken TokenResponse
    {
        get
        {
            if (Choice != Option.TokenResponse)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.TokenResponse)} hat das Template erstellt");
            }
            return (AccessToken)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The access token returned in response to the authentication request.
    /// </summary>
    public static AuthRequestAck NewTokenResponse(AccessToken value)
    {
        return new AuthRequestAck(Option.TokenResponse, value);
    }
}
