﻿using Sirenix.OdinInspector;
using UnityEngine;

namespace GD.Types
{
    /// <summary>
    /// Base class for all scriptable objects in the game.
    /// Adds name, description, and reset functionality.
    /// </summary>
    /// <see cref="GD.Items.ItemData"/>
    public class ScriptableGameObject : ScriptableObject
    {
        #region Fields

        [FoldoutGroup("Info", expanded: false)]
        [ShowInInspector, Tooltip("Unique identifier for this object."), ReadOnly]
        private string uniqueID;

        [SerializeField]
        [ContextMenuItem("Reset Name", "ResetName")]
        [FoldoutGroup("Info")]
        private new string name = string.Empty;

        [SerializeField]
        [ContextMenuItem("Reset Description", "ResetDescription")]
        [TextArea(2, 4)]
        [FoldoutGroup("Info")]
        private string description = string.Empty;

        #endregion Fields

        #region Properties

        public string UniqueID { get => uniqueID; }

        public string Name { get => name; set => name = value; }

        public string Description { get => description; set => description = value; }

        #endregion Properties

        #region Core Methods

        /// <summary>
        /// Automatically generates a unique ID using a GUID if one isn't already set.
        /// </summary>
        private void OnValidate()
        {
            if (string.IsNullOrEmpty(uniqueID))
            {
                uniqueID = System.Guid.NewGuid().ToString();
#if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(this);
#endif
            }
        }

        /// <summary>
        /// Resets the name to an empty string
        /// </summary>
        public void ResetName()
        {
            Name = string.Empty;
        }

        /// <summary>
        /// Resets the description to an empty string
        /// </summary>
        public void ResetDescription()
        {
            Description = string.Empty;
        }

        /// <summary>
        /// Overridden in child classes to specify what a reset means (e.g. clear the list, reset the int, empty the string
        /// </summary>
        public virtual void Reset()
        {
            //noop - (no operation - not called)
        }

        #endregion Core Methods
    }
}