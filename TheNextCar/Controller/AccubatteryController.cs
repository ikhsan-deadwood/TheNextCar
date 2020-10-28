using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class AccubatteryController
    {
        private Accubattery accubattery;
        private OnPowerChanged callbackOnPowerChanged;

        public AccubatteryController(OnPowerChanged callbackOnPowerChanged)
        {
            this.callbackOnPowerChanged = callbackOnPowerChanged;
            this.accubattery = new Accubattery(12);
        }
        public void turnOn()
        {
            this.accubattery.turnOn();
            this.callbackOnPowerChanged.OnPowerChangedStatus("On", "power is on");
        }
        public void turnOff()
        {
            this.accubattery.turnOff();
            this.callbackOnPowerChanged.OnPowerChangedStatus("Off", "power is off");
        }

        public bool accubatteryIsOn()
        {
            return this.accubattery.isOn();
        }
    }

    interface OnPowerChanged
    {
        void OnPowerChangedStatus(string value, string message);
    }
}
