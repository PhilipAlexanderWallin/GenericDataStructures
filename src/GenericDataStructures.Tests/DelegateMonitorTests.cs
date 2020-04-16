using NUnit.Framework;

namespace GenericDataStructures.Tests
{
    public class DelegateMonitorTests
    {
        private DelegateMonitor _delegateMonitor = new DelegateMonitor();

        [SetUp]
        public void SetUp()
        {
            _delegateMonitor = new DelegateMonitor();
        }

        [Test]
        public void TypeCallsAreZeroIfUntouched()
        {
            Assert.AreEqual(0, _delegateMonitor.TotalCalls);
            Assert.AreEqual(0, _delegateMonitor.GetCalls(typeof(string)));
        }

        [Test]
        public void TypeCallsAreAdded()
        {
            _delegateMonitor.NoOperation(string.Empty);
            _delegateMonitor.NoOperation(string.Empty);
            Assert.AreEqual(2, _delegateMonitor.GetCalls(typeof(string)));
        }

        [Test]
        public void MixedTypeCallsAreCountedSeparately()
        {
            _delegateMonitor.NoOperation(string.Empty);
            _delegateMonitor.ConvertToString(string.Empty);
            _delegateMonitor.NoOperation(string.Empty);
            _delegateMonitor.NoOperation(1);
            Assert.AreEqual(3, _delegateMonitor.GetCalls(typeof(string)));
            Assert.AreEqual(1, _delegateMonitor.GetCalls(typeof(int)));
        }

        [Test]
        public void TotalCallsCountAllCalls()
        {
            _delegateMonitor.NoOperation(string.Empty);
            _delegateMonitor.ConvertToString(string.Empty);
            _delegateMonitor.NoOperation(string.Empty);
            _delegateMonitor.NoOperation(1);
            Assert.AreEqual(4, _delegateMonitor.TotalCalls);
        }
    }
}
