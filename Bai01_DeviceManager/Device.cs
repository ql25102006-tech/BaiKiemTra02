namespace Bai01_DeviceManager
{
    public class Device
    {
        public string DeviceId { get; set; } = string.Empty;
        public string DeviceName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Device() { }

        public Device(string id, string name, string category, decimal price, int quantity)
        {
            DeviceId = id;
            DeviceName = name;
            Category = category;
            Price = price;
            Quantity = quantity;
        }
    }
}
