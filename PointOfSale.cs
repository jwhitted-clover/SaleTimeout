using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.clover.remotepay.sdk;
using com.clover.remotepay.transport;

namespace SaleTimeout
{
    public class PointOfSale
    {
        public ICloverConnector Connector { get; set; }

        public PointOfSale()
        {
            var connector = CloverConnectorFactory.CreateUsbConnector("RAID", "Point of Sale", "Register101", false);
            connector.AddCloverConnectorListener(new Listener(this));
            connector.InitializeConnection();
            connector.RetrieveDeviceStatus(new RetrieveDeviceStatusRequest { sendLastMessage = true });
            Connector = connector;
        }

        public void Run()
        {
            var command = "help";
            while (true)
            {
                switch (command)
                {
                    case "help":
                        Program.WriteLine(string.Join(Environment.NewLine,
                            "COMMANDS:",
                            "  help   - Displays help",
                            "  sale   - Performs a sale",
                            "  status - Retrieves the device status",
                            "  resend - Resends the last device message",
                            "  enter  - Sends 'ENTER' key to device",
                            "  esc    - Sends 'ESC' key to device",
                            "  reset  - Resets the device",
                            "  exit   - Exits the program"
                        ), ConsoleColor.White);
                        break;
                    case "sale":
                        Connector.Sale(new SaleRequest { Amount = 123, ExternalId = ExternalIDUtil.GenerateRandomString(32) });
                        break;
                    case "status":
                        Connector.RetrieveDeviceStatus(new RetrieveDeviceStatusRequest { sendLastMessage = false });
                        break;
                    case "resend":
                        Connector.RetrieveDeviceStatus(new RetrieveDeviceStatusRequest { sendLastMessage = true });
                        break;
                    case "enter":
                        // NOTE: The input option is listed in the 'timeout' CloverDeviceEvent in ICloverConnectorListener.OnDeviceActivityStart
                        Connector.InvokeInputOption(new InputOption { description = "OK", keyPress = KeyPress.ENTER });
                        break;
                    case "esc":
                        Connector.InvokeInputOption(new InputOption { description = "ESC", keyPress = KeyPress.ENTER });
                        break;
                    case "reset":
                        Connector.ResetDevice();
                        break;
                    case "exit":
                        return;
                }
                command = Program.Prompt("Command?");
            }
        }
    }
}
