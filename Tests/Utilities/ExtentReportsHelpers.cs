
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace Tests.Utilities
{
    public abstract class ExtentReportsHelpers
    {
        // Variables & Constants
        public readonly ExtentReports extent = new ExtentReports();
        public ExtentTest test;

        // Actions
        public abstract void RecordTestOutcomeToExtent(ExtentTest test, ResultState outcome, string message);
    }
}

