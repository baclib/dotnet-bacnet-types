// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice AuthRequest-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuthRequestRequest
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// A request for an access token.
        /// </summary>
        TokenRequest
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private AuthRequestRequest(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// A request for an access token.
    /// </summary>
    public TTokenRequest TokenRequest
    {
        get
        {
            if (Choice != Option.TokenRequest)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.TokenRequest)}.");
            }
            return (TTokenRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.TokenRequest"/>.
    /// </summary>
    public bool TryGetTokenRequest(out TTokenRequest value)
    {
        if (Choice == Option.TokenRequest)
        {
            value = (TTokenRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.TokenRequest"/> option.
    /// </summary>
    public static AuthRequestRequest FromTokenRequest(TTokenRequest value)
    {
        return new AuthRequestRequest(Option.TokenRequest, value);
    }
}
