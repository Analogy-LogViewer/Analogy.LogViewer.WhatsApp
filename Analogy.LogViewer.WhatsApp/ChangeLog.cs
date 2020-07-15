using System;
using System.Collections.Generic;
using Analogy.Interfaces;

namespace Analogy.LogViewer.WhatsApp
{
    public static class ChangeLog
    {
        public static IEnumerable<AnalogyChangeLog> GetChangeLog()
        {
            yield return new AnalogyChangeLog("Add Source Link To Project (issue #9)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2020, 01, 05));
            yield return new AnalogyChangeLog("Parsing Setting are not loaded in the user setting windows (issue #8)", AnalogChangeLogType.Bug, "Lior Banai", new DateTime(2019, 12, 19));
            yield return new AnalogyChangeLog("Deserialization of settings fails (issue #5)", AnalogChangeLogType.Bug, "Lior Banai", new DateTime(2019, 12, 11));
            yield return new AnalogyChangeLog("NLog Data Provider: standalone release", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 11, 13));

        }
    }
}
