using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Legacy;
using NSubstitute;
using NUnit.Framework;

namespace ECS.Test.Unit
{
    [TestFixture]
    public class EcsUnitTest
    {
        private IHeater _heater;
        private ITempSensor _tempSensor;
        private ECSControl _uut;
        private int _threshold;

        [SetUp]
        public void Setup()
        {
            _heater = Substitute.For<IHeater>();
            _tempSensor = Substitute.For<ITempSensor>();
            _uut = new ECSControl(_threshold,_tempSensor,_heater);

        }

        [TestCase(30)]
        [TestCase(25)]
        public void Threshold_Set_ThresholdIsCorrect(int temp)
        {
            _uut.SetThreshold(temp);

            Assert.That(_uut.GetThreshold(), Is.EqualTo(temp));
        }

    }
}
