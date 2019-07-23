using System;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using com.clover.remotepay.sdk;
using com.clover.remotepay.transport;
using Newtonsoft.Json;

namespace SaleTimeout
{
    public class Listener : ICloverConnectorListener
    {
        #region Properties
        public PointOfSale Pos { get; set; }
        #endregion


        #region Constructors
        public Listener(PointOfSale pos)
        {
            Pos = pos;
        }
        #endregion


        #region Methods
        public void OnAuthResponse(AuthResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnCapturePreAuthResponse(CapturePreAuthResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnCloseoutResponse(CloseoutResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnConfirmPaymentRequest(ConfirmPaymentRequest request)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
            Program.WriteLine("Accepting Payment");
            Pos.Connector.AcceptPayment(request.Payment);
        }

        public void OnCustomActivityResponse(CustomActivityResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnCustomerProvidedData(CustomerProvidedDataEvent response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnDeviceActivityEnd(CloverDeviceEvent deviceEvent)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name, deviceEvent);
        }

        public void OnDeviceActivityStart(CloverDeviceEvent deviceEvent)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name, deviceEvent);
        }

        public void OnDeviceConnected()
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnDeviceDisconnected()
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnDeviceError(CloverDeviceErrorEvent deviceErrorEvent)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name, deviceErrorEvent, ConsoleColor.Red);
        }

        public void OnDeviceReady(MerchantInfo merchantInfo)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name, ConsoleColor.Green);
        }

        public void OnDisplayReceiptOptionsResponse(DisplayReceiptOptionsResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnInvalidStateTransitionResponse(InvalidStateTransitionNotification message)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnManualRefundResponse(ManualRefundResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnMessageFromActivity(MessageFromActivity response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnPreAuthResponse(PreAuthResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnPrintJobStatusRequest(PrintJobStatusRequest request)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnPrintJobStatusResponse(PrintJobStatusResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnPrintManualRefundDeclineReceipt(PrintManualRefundDeclineReceiptMessage message)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnPrintManualRefundReceipt(PrintManualRefundReceiptMessage message)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnPrintPaymentDeclineReceipt(PrintPaymentDeclineReceiptMessage message)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnPrintPaymentMerchantCopyReceipt(PrintPaymentMerchantCopyReceiptMessage message)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnPrintPaymentReceipt(PrintPaymentReceiptMessage message)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnPrintRefundPaymentReceipt(PrintRefundPaymentReceiptMessage message)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnReadCardDataResponse(ReadCardDataResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnRefundPaymentResponse(RefundPaymentResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnResetDeviceResponse(ResetDeviceResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnRetrieveDeviceStatusResponse(RetrieveDeviceStatusResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name, response);
        }

        public void OnRetrievePaymentResponse(RetrievePaymentResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnRetrievePendingPaymentsResponse(RetrievePendingPaymentsResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnRetrievePrintersResponse(RetrievePrintersResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnSaleResponse(SaleResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name, response);
        }

        public void OnTipAdded(TipAddedMessage message)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnTipAdjustAuthResponse(TipAdjustAuthResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnVaultCardResponse(VaultCardResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnVerifySignatureRequest(VerifySignatureRequest request)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
            Program.WriteLine("Accepting Signature");
            request.Accept();
            Pos.Connector.AcceptSignature(request);
        }

        public void OnVoidPaymentRefundResponse(VoidPaymentRefundResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void OnVoidPaymentResponse(VoidPaymentResponse response)
        {
            Program.WriteLine(MethodBase.GetCurrentMethod().Name);
        }
        #endregion
    }
}

