﻿
using System.Text.Json.Serialization;
using Dock.Model.Core;

namespace Dock.Model.Controls
{
    /// <summary>
    /// Proportional dock contract.
    /// </summary>
    public interface IProportionalDock : IDock
    {
        /// <summary>
        /// Gets or sets layout orientation.
        /// </summary>
        [JsonInclude]
        Orientation Orientation { get; set; }
    }
}
