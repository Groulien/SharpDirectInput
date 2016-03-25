namespace TestApplication {
    using SharpDirectInput;
    internal class DeviceInfo {
        public DeviceInfo(DeviceInstance backend) {
            this.Device = backend;
            Name = backend.GetProductName();
        }
        public string Name {
            get;
            protected set;
        }
        public DeviceInstance Device {
            get;
            protected set;
        }
    }
}
