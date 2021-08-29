﻿
using System.Text.Json.Serialization;
using System.Windows.Input;
using Dock.Model.Core;

namespace Dock.Model.Controls
{
    /// <summary>
    /// Document dock contract.
    /// </summary>
    public interface IDocumentDock : IDock
    {
        /// <summary>
        /// Gets or sets if document dock can create new documents.
        /// </summary>
        [JsonInclude]
        bool CanCreateDocument { get; set; }

        /// <summary>
        /// Gets or sets command to create new document.
        /// </summary>
        [JsonIgnore]
        ICommand? CreateDocument { get; set; }
    }
}
