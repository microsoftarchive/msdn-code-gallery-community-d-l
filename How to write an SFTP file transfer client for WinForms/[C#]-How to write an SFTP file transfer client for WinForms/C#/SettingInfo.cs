using System.Collections.Generic;

namespace ClientSample
{
    public delegate void SaveConfigDelegate(SettingInfoBase settings);
    public delegate void LoadConfigDelegate(SettingInfoBase settings);

    public class SettingInfoBase
    {
        private Dictionary<string, object> _values;

        public T Get<T>(string key)
        {
            return (T)_values[key];
        }

        public void Set(string key, object value)
        {
            _values[key] = value;
        }

        #region Methods

        public void SaveProperty(string name)
        {
            Util.SaveProperty(name, _values[name]);
        }

        public void LoadProperty(string name, int defaultValue)
        {
            _values[name] = Util.GetIntProperty(name, defaultValue);
        }

        public void LoadProperty(string name, bool defaultValue)
        {
            _values[name] = Util.GetProperty(name, defaultValue.ToString()).ToString() == "True";
        }

        public void LoadProperty(string name, object defaultValue)
        {
            _values[name] = Util.GetProperty(name, defaultValue);
        }

        public virtual void SaveConfig(params SaveConfigDelegate[] saveDelegates)
        {
            for (int i = 0; i < saveDelegates.Length; i++)
                saveDelegates[i](this);
        }

        public virtual void LoadConfig(params LoadConfigDelegate[] loadDelegates)
        {
            _values = new Dictionary<string, object>();
            for (int i = 0; i < loadDelegates.Length; i++)
                loadDelegates[i](this);
        }

        #endregion
    }

    public class SettingInfo
    {
        public const string KeepAlive = "KeepAlive";
        public const string Throttle = "Throttle";
        public const string Timeout = "Timeout";
        public const string AsciiTransfer = "AsciiTransfer";
        public const string ProgressUpdateInterval = "ProgressUpdateInterval";
        public const string ShowProgressWhileDeleting = "ShowProgressWhileDeleting";
        public const string ShowProgressWhileTransferring = "ShowProgressWhileTransferring";
        public const string RestoreFileProperties = "RestoreFileProperties";

        public static void SaveConfig(SettingInfoBase settings)
        {
            // Save settings.
            settings.SaveProperty(Throttle);
            settings.SaveProperty(Timeout);
            settings.SaveProperty(KeepAlive);
            settings.SaveProperty(AsciiTransfer);
            settings.SaveProperty(ProgressUpdateInterval);
            settings.SaveProperty(ShowProgressWhileDeleting);
            settings.SaveProperty(ShowProgressWhileTransferring);
            settings.SaveProperty(RestoreFileProperties);
        }

        public static void LoadConfig(SettingInfoBase settings)
        {
            settings.LoadProperty(Throttle, 0);
            settings.LoadProperty(Timeout, 30);
            settings.LoadProperty(KeepAlive, 60);
            settings.LoadProperty(AsciiTransfer, false);
            settings.LoadProperty(ProgressUpdateInterval, 500);
            settings.LoadProperty(ShowProgressWhileDeleting, false);
            settings.LoadProperty(ShowProgressWhileTransferring, true);
            settings.LoadProperty(RestoreFileProperties, false);
        }
    }
}
