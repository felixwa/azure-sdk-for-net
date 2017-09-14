// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.RecoveryServices;
    using Microsoft.Azure.Management.RecoveryServices.SiteRecovery;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// class to define the health summary of the Vault.
    /// </summary>
    public partial class VaultHealthProperties
    {
        /// <summary>
        /// Initializes a new instance of the VaultHealthProperties class.
        /// </summary>
        public VaultHealthProperties()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the VaultHealthProperties class.
        /// </summary>
        /// <param name="vaultErrors">The list of errors on the vault.</param>
        /// <param name="protectedItemsHealth">The list of the health detail of
        /// the protected items in the vault.</param>
        /// <param name="fabricsHealth">The list of the health detail of the
        /// fabrics in the vault.</param>
        public VaultHealthProperties(IList<HealthError> vaultErrors = default(IList<HealthError>), ResourceHealthSummary protectedItemsHealth = default(ResourceHealthSummary), ResourceHealthSummary fabricsHealth = default(ResourceHealthSummary))
        {
            VaultErrors = vaultErrors;
            ProtectedItemsHealth = protectedItemsHealth;
            FabricsHealth = fabricsHealth;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the list of errors on the vault.
        /// </summary>
        [JsonProperty(PropertyName = "vaultErrors")]
        public IList<HealthError> VaultErrors { get; set; }

        /// <summary>
        /// Gets or sets the list of the health detail of the protected items
        /// in the vault.
        /// </summary>
        [JsonProperty(PropertyName = "protectedItemsHealth")]
        public ResourceHealthSummary ProtectedItemsHealth { get; set; }

        /// <summary>
        /// Gets or sets the list of the health detail of the fabrics in the
        /// vault.
        /// </summary>
        [JsonProperty(PropertyName = "fabricsHealth")]
        public ResourceHealthSummary FabricsHealth { get; set; }

    }
}