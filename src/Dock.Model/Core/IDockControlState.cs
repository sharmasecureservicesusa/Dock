﻿
using System.Text.Json.Serialization;

namespace Dock.Model.Core
{
    /// <summary>
    /// Dock control state contract.
    /// </summary>
    public interface IDockControlState
    {
        /// <summary>
        /// Gets or sets dock manager.
        /// </summary>
        [JsonIgnore]
        IDockManager DockManager { get; set; }
    }
}
