namespace com.tp.pattern.observer
{
    /// <summary>
    /// Interface for Observables say all radio stations
    /// </summary>
    interface IPaidNewsChannels
    {
        /// <summary>
        /// Add a new subscriber aka observer
        /// </summary>
        void SubscribeMe(IChannelUsers user);
        /// <summary>
        /// Remove a subscriber aka an observer
        /// </summary>
        void UnSubscribeMe(IChannelUsers user);
        /// <summary>
        /// Notify all the observers err send latest news to all the subscribers
        /// </summary>
        void NotifySubscribers();
    }
}
