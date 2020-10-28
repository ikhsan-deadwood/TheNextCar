using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNextCar.Controller
{
    class Car
    {
        private DoorController doorController;
        private AccubatteryController accubatteryController;
        private OnCarEngineStateChanged callback;
        private MainWindow mainWindow;

        public Car(DoorController doorController, AccubatteryController accubatteryController, OnCarEngineStateChanged callback)
        {
            this.doorController = doorController;
            this.accubatteryController = accubatteryController;
            this.callback = callback;
        }

        public Car(DoorController doorcontroller, AccubatteryController accubatteryController, MainWindow mainWindow)
        {
            doorController = doorcontroller;
            this.accubatteryController = accubatteryController;
            this.mainWindow = mainWindow;
        }

        private bool doorisClosed()
        {
            return this.doorController.isClose();
        }
        private bool doorisLocked()
        {
            return this.doorController.isLocked();
        }
        private bool powerIsReady()
        {
            return this.accubatteryController.accubatteryIsOn();
        }
        public void startEngine()
        {
            if (!doorisClosed())
            {
                this.callback.OnCarEngineStateChanged("STOPED", "Close the door");
                return;
            }
            if (!doorisLocked())
            {
                this.callback.OnCarEngineStateChanged("LOCKED", "Lock the door");
                return;
            }

            if (!powerIsReady())
            {
                this.callback.OnCarEngineStateChanged("STOPED", "no power  available");
                return;
            }

            this.callback.OnCarEngineStateChanged("STARTED", "Engine Started");
        }

        public void toggleTheLockDoorButton()
        {
            if (!doorisLocked())
            {
                this.doorController.activateLock();
            }
            else
            {
                this.doorController.unlock();
            }
        }
        public void toggleTheOpenDoorButton()
        {
            if (!doorisClosed())
            {
                this.doorController.close();
            }
            else
            {
                this.doorController.open();
            }
        }
        public void togglePowerButton()
        {
            if (!powerIsReady())
            {
                this.accubatteryController.turnOn();
            }
            else
            {
                this.accubatteryController.turnOff();
            }
        }
    }
    interface OnCarEngineStateChanged
    {
        void OnCarEngineStateChanged(string value, string message);
    }
}