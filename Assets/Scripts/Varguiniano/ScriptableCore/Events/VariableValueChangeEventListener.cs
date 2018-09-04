using Varguiniano.ScriptableCore.Core;

namespace Varguiniano.ScriptableCore.Events
{
    /// <inheritdoc />
    /// <summary>
    /// Class that listens to the OnValueChangeEvent of a given variable.
    /// </summary>
    public abstract class VariableValueChangeEventListener<T> : GameEventListener
    {
        /// <summary>
        /// Variable to listen to.
        /// </summary>
        protected Variable<T> VariableToListen;
        
        /// <inheritdoc />
        /// <summary>
        /// Register to the event.
        /// </summary>
        protected override void OnEnable()
        {
            GameEvent = VariableToListen.OnValueChanged;
            base.OnEnable();
            Response.AddListener(OnValueChanged);
        }
        
        /// <inheritdoc />
        /// <summary>
        /// Unregister from the event.
        /// </summary>
        protected override void OnDisable()
        {
            Response.RemoveListener(OnValueChanged);
            base.OnDisable();
        }

        /// <summary>
        /// On value changed called to be implemented by children.
        /// </summary>
        protected abstract void OnValueChanged();
    }
}