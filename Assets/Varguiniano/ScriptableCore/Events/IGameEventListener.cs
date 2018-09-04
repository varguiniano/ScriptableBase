namespace Varguiniano.ScriptableCore.Events
{
    /// <summary>
    /// Interface that defines how scriptable based events should be listened to.
    /// </summary>
    public interface IGameEventListener
    {
        /// <summary>
        /// Called when the event is raised.
        /// </summary>
        void EventRaised();

        /// <summary>
        /// This is the monobehaviour call where to register to the event.
        /// </summary>
        void OnEnable();

        /// <summary>
        /// This is the monobehaviour call where to unregister to the event.
        /// </summary>
        void OnDisable();
    }
}