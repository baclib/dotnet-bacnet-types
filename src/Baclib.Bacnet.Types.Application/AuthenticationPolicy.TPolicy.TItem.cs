// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class AuthenticationPolicy
{
    public partial record class TPolicy
    {
        /// <summary>
        /// Represents the sequence ??? as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TItem
        {
            /// <summary>
            /// Reference to the device object that provides credential data input.
            /// </summary>
            public required DeviceObjectReference CredentialDataInput { get; init; }
            
            /// <summary>
            /// The index or sequence number of this credential input in the policy.
            /// </summary>
            public required Unsigned Index { get; init; }
            }
    }
}
