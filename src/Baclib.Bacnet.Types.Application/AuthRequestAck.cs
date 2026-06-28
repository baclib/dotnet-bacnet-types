// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

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

    private readonly object _choiceValue;

    private AuthRequestAck(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.TokenResponse)}.");
            }
            return (AccessToken)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.TokenResponse"/>.
    /// </summary>
    public bool TryGetTokenResponse(out AccessToken value)
    {
        if (Choice == Option.TokenResponse)
        {
            value = (AccessToken)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.TokenResponse"/> option.
    /// </summary>
    public static AuthRequestAck FromTokenResponse(AccessToken value)
    {
        return new AuthRequestAck(Option.TokenResponse, value);
    }
}
